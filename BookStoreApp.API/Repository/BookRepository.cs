using BookStoreApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.BookStore.Repository
{
    public class BookRepository
    {
        public IEnumerable<BookModel> GetAllBook()
        {
            return DataSource(); 
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();          
        }
        public BookModel SearchBook(string title)
        {
            return DataSource().Where(x => x.Title.Contains(title)).FirstOrDefault();
        }

        private List<BookModel> DataSource()
        {
            List<BookModel> bookModels = new List<BookModel>()
            {
                new BookModel(){ Id=1, Title= "My Journey", Author= "Dr. A.P.J. Abdul Kalam", Imageurl="https://images-na.ssl-images-amazon.com/images/I/61jrrdV3EaL.jpg", Description="From a small boy growing up in Rameswaram, to becoming the country's eleventh President, A.P.J. Abdul Kalam's life has been a tale of extraordinary determination, courage, perseverance and the desire to excel. In this series of anecdotes and profiles, Dr Kalam looks back on key moments in his past-some small and some momentous-and tells the reader how each of them inspired him profoundly."},
                new BookModel(){ Id=2, Title= "Why I am hindu", Author= "Shashi Tharoor", Imageurl="https://images-na.ssl-images-amazon.com/images/I/51oeb-OqsJL.jpg", Description="In Why I Am a Hindu, Shashi Tharoor offers a profound reexamination of Hinduism, one of the world's oldest and greatest religious traditions. Opening with a frank and touching reflection on his personal beliefs, he lays out Hinduism's origins and its key philosophical concepts -- including Vedanta, the Purusharthas and Bhakti -- before focusing on texts such as the Bhagadvagita."},
                new BookModel(){ Id=3, Title= "Love A Little Stronger", Author= "Preeti Shenoy", Imageurl="https://images-na.ssl-images-amazon.com/images/I/51LFoFBwLwL._SX327_BO1,204,203,200_.jpg", Description="Life is a collection of moments, some memorable and some mundane. Often it is the tiniest things that bring the greatest joy, even though at that time, we have no idea that what we are witnessing may be magical, something that we will talk about and laugh over after many years."},
                new BookModel(){ Id=4, Title= "The Paradoxical Prime Minister", Author= "Shashi Tharoor", Imageurl="https://bookverse.in/wp-content/uploads/2021/03/The-Paradoxical-Prime-MinisterNarendra-Modi-And-His-India.jpg", Description="The Paradoxical Prime Minister: Narendra Modi And His India is a 2018 non-fiction book written by senior leader of the Indian National Congress, Shashi Tharoor, about the Prime Minister of India, Narendra Modi. The book was released on 26 October, 2018 by Manmohan Singh, P. Chidambaram, Arun Shourie, and Pavan Varma."},
                new BookModel(){ Id=5, Title= "The Coalition years", Author= "Pranab Mukherjee", Imageurl="https://images-na.ssl-images-amazon.com/images/I/51OyPxVWG+L.jpg", Description="The Coalition Years begins its journey in 1996 and explores the highs and lows that characterized sixteen years of one of the most tumultuous periods in the nation's political history. It is an insightful account of the larger governance phenomenon in India-coalition politics-as seen through the eyes of one of the chief architects of the post-Congress era of Indian politics."}
            };
            return bookModels;
        } 
    }
}
