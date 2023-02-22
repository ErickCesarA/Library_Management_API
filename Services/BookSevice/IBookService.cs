namespace Library_ManagementAPI.Services.BookSevice
{
    public interface IBookService
    {
        Task<List<BooksModels>> GetAllBooks();
        Task<List<BooksModels>?> GetBooks(string bookTitle, string bookSubTitle, string bookAutor, string bookGenres, string bookPublisher, string bookEdition);
        Task<List<BooksModels>?> GetBooksGenres(string bookGenres);
        Task<List<BooksModels>> AddBooks(BooksModels book);
        Task<List<BooksModels>?> UpdBooks(string bookTitle, BooksModels request);
        Task<List<BooksModels>?> DelBooks(string bookTitle);

    }
}
