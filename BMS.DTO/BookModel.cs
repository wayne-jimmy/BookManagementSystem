

namespace BMS.DTO
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            this.BookId = 0;
            this.Title = string.Empty;
            this.Author = string.Empty;
            this.Genre = string.Empty;
            this.PublicationYear = 0;
            this.Price = 0;
        }

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public int PublicationYear { get; set; }

        public decimal Price { get; set; }
    }
}
