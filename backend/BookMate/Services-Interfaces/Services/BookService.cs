using BookMate.Data_Models;
using Microsoft.EntityFrameworkCore;

namespace BookMate.Services_Interfaces.Services
{
    public class BookService //: IBook
    {
        //using simple in memory list to store books and retervie from it
        //this approach (using inmemory list) is not good because it only holds data while application running . after stoping the application data will be gone. 
        private List<Book> books = new List<Book>();

        public string AddBook(Book book) 
        {
            book.Id = books.Count > 0 ? books[^1].Id + 1 : 1;
            books.Add(book);
            return "saved";
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(book => book.Id ==id);
        }

        public string UpdateBook(int id, Book book)
        {
            var currentBook = books.FirstOrDefault(book => book.Id == id);

            if (currentBook != null)
            {
                currentBook.Author = book.Author;
                currentBook.Title = book.Title;
                currentBook.Isbn = book.Isbn;
                currentBook.PublicationDate = book.PublicationDate;

                return "updated";
            }
            else
            {
                return "error";
            }
        }

        public string DeleteBook(int id) 
        {
            var currentBook = books.FirstOrDefault(book => book.Id == id);

            if (currentBook != null)
            {
                books.Remove(currentBook);
                return "Deleted";
            }
            else
            {
                return "Error";
            }
        }



// this approach is used to handle when there is a datatabse to store book detials - it only written to demonstration purposes 
//in this case there is interface called IBook and this class implement that interfaces method, and also in program.cs file there should be Addscopemethod to add this service class and corresponding interface


        //private readonly AppDBContext _dbContext;
        //public BookService(AppDBContext dBContext)
        //{
        //    _dbContext = dBContext;
        //}

        //public async Task<List<Book>> GetAllBooks()
        //{
        //    var booklist = await _dbContext.Books.ToListAsync();
        //    return booklist;
        //}

        //public async Task<string> AddBook(Book book)
        //{
        //    _dbContext.Books.Add(book);
        //    await _dbContext.SaveChangesAsync();
        //    return "Book added succesffully";
        //}

        //public async Task<Book> GetById(int id)
        //{
        //    return await _dbContext.Books.FindAsync(id);
        //}

        //public async Task<string> UpdateBookById(int id, Book book)
        //{
        //    var currentBook = await _dbContext.Books.FindAsync(book.Id);

        //    if (currentBook != null)
        //    {
        //        _dbContext.Entry(currentBook).CurrentValues.SetValues(book);
        //        await _dbContext.SaveChangesAsync(true);

        //        return "Update successfull";
        //    }
        //    else {
        //        return "Couldnt find the book you requested";
        //    }
        //}

        //public async Task<string> DeleteBookById(int id)
        //{
        //    await _dbContext.Books.Where(book => book.Id == id).ExecuteDeleteAsync();
        //    return "Successfully deleted";

        //}

        //public async Task SaveChanges()
        //{
        //    await _dbContext.SaveChangesAsync();   
        //}
    }
}
