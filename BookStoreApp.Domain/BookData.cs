using Microsoft.EntityFrameworkCore;
using BookStoreApp.Contracts.Interface;
using BookStoreApp.Contracts.Models;
using BookStoreApp.Repository.DataAccess.SQL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Domain
{
    public class BookData : IBookData
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookData(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public int TotalBookCount()
        {
            int count = _bookStoreContext.BookModels.Count();
            return count;
        }
        public async Task<int> CreateNewBook(BookModel bookModel)
        {
            bookModel.CreatedDate = DateTime.Now;
            await _bookStoreContext.BookModels.AddAsync(bookModel);
            await SaveChanges();
            return bookModel.Id;
        }

        public async Task<IEnumerable<BookModel>> GetAllBook()
        {
            var data =  _bookStoreContext.BookModels.ToList();
            return data;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var data = _bookStoreContext.BookModels.FirstOrDefault(x => x.Id == id);
            return(data);
        }
        public async Task<string> DeleteBookById(int id)
        {
            //_empDetailContext.Remove(_empDetailContext.EmpDetails.Single(p => p.id == id));
            _bookStoreContext.Remove(_bookStoreContext.BookModels.Single(x=> x.Id == id));
            await SaveChanges();
            return "success";
        }
        public async Task<int> UpdateBookById(BookModel bookModel)
        {
            if (bookModel == null)
            {
                return 0;
            }
            else
            {
                BookModel result = await (from p in _bookStoreContext.BookModels
                                          where p.Id == bookModel.Id
                                          select p).SingleAsync();
              
                result.Title = bookModel.Title;
                result.Author = bookModel.Author;
                result.Description = bookModel.Description;
                result.Imageurl = bookModel.Imageurl;
                result.UpdatedDate = DateTime.Now;
                await SaveChanges();

                return bookModel.Id;
            }
        }

        public async Task<bool> SaveChanges()
        {
            return (await _bookStoreContext.SaveChangesAsync() >= 0);
        }

        
    }
}
