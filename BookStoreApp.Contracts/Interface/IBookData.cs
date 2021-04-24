using BookStoreApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Contracts.Interface
{
    public interface IBookData
    {
        Task<bool> SaveChanges();
        int TotalBookCount();
        Task<IEnumerable<BookModel>> GetAllBook();
        Task<BookModel> GetBookById(int id);
        Task<string> DeleteBookById(int id);
        Task<int> UpdateBookById(BookModel bookModel);
        Task<int> CreateNewBook(BookModel bookModel);
    }
}
