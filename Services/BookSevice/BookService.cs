using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Library_ManagementAPI.Services.BookSevice
{
    public class BookService : IBookService
    {
        private static List<BooksModels> books = new List<BooksModels>
        {
            new BooksModels {}
        };
        private readonly DataContext _context;
        public BookService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BooksModels>> GetAllBooks()
        {
            var books = await _context.BooksPropety.ToListAsync();
            return books;
        }
        public async Task<List<BooksModels>?> GetBooks(string booktitle, string booksubtitle,
                                                            string bookautor, string bookgenres,
                                                            string bookpublisher, string bookedition)
        {
            var books = await _context.BooksPropety.Where(bt => bt.bookTitle.Contains(booktitle))
                                                   .Where(bt => bt.bookSubTitle.Contains(booksubtitle))
                                                   .Where(bt => bt.bookAutor.Contains(bookautor))
                                                   .Where(bt => bt.bookGenres.Contains(bookgenres))
                                                   .Where(bt => bt.bookPublisher.Contains(bookpublisher))
                                                   .Where(bt => bt.bookEdition.Contains(bookedition)).ToListAsync();
            if (books == null)
                return null;

            return books;
        }
        public async Task<List<BooksModels>?> GetBooksGenres(string bookgenres)
        { 
            var books = await _context.BooksPropety.Where(bg => bg.bookGenres.Contains(bookgenres)).ToListAsync();
                if (books ==null) 
                    return null;   
            return books;
        }
        public async Task<List<BooksModels>> AddBooks(BooksModels book)
        {
            _context.BooksPropety.Add(book);
            await _context.SaveChangesAsync();
            return books;
        }
        public async Task<List<BooksModels>?> UpdBooks(string booktitle, BooksModels request)
        {
            var book = await _context.BooksPropety.Where(bt => bt.bookTitle.Contains(booktitle)).FirstOrDefaultAsync();
            if (book == null)
                return null;

            book.bookTitle = request.bookTitle;
            book.bookSubTitle = request.bookSubTitle;
            book.bookResume = request.bookResume;
            book.bookAutor = request.bookAutor;
            book.bookGenres = request.bookGenres;
            book.bookPublisher = request.bookPublisher;
            book.bookEdition = request.bookEdition;
            book.bookPublication = request.bookPublication;
            book.bookCopies = request.bookCopies;
            book.bookPgNumber = request.bookPgNumber;

            await _context.SaveChangesAsync();

            return books;
        }
        public async Task<List<BooksModels>?> DelBooks(string booktitle)
        {
            var book = await _context.BooksPropety.Where(bt => bt.bookTitle.Contains(booktitle)).FirstOrDefaultAsync();
            if (book == null)
                return null;

            _context.BooksPropety.Remove(book);
            await _context.SaveChangesAsync();
            return books;
        }
    }
}
