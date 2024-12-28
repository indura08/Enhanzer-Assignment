using BookMate.Data_Models;

namespace BookMate.Services_Interfaces
{
    public interface IBook
    {
        Task<List<Book>> GetAllBooks();
        Task<string> AddBook(Book book);
        Task<Book> GetById(int id);
        Task<string> UpdateBookById(int id, Book book);
        Task<string> DeleteBookById(int id);
        Task SaveChanges();
    }
}
