namespace BookRecordApp.Models
{
    public class BookRecord
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Count { get; set; }
    }
}
