namespace Library_ManagementAPI.Models
{
    public class BooksModels
    {
        public int ID { get; set; }
        public string bookTitle { get; set; } = string.Empty;
        public string bookSubTitle { get; set; } = string.Empty;
        public string bookResume { get; set; } = string.Empty;
        public string bookAutor { get; set; } = string.Empty;
        public string bookGenres { get; set; } = string.Empty;
        public string bookPublisher { get; set; } = string.Empty;
        public string bookEdition { get; set; } = string.Empty;
        public DateTime bookPublication { get; set; }
        public int bookCopies { get; set; }
        public int bookPgNumber { get; set; }

    }
}
