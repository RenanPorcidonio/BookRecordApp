using System.ComponentModel.DataAnnotations;

namespace BookRecordApp.Models
{
    public enum BookStatus
    {
        [Display(Name = "Plan to Read")]
        PlanToRead,
        Reading,
        Completed,
        Dropped
    }

    public class BookRecord
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Book Title")]
        public string BookName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Vezes Lido")]
        public int Count { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [Required]
        public BookStatus Status { get; set; } = BookStatus.PlanToRead;

        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }
    }
}
