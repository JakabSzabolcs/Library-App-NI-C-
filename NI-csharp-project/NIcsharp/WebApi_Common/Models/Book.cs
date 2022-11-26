using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Common.Models
{
    public class Book
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Author field is required!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Title field is required!")]
        public string Title { get; set; }

        [Required]
        public bool IsBorrowed { get; set; }

        [BorrowerNameValidation]
        public string NameOfBorrower { get; set; }

        public DateTime DateOfBorrowing { get; set; }

        [ReturnDateValidation]
        public DateTime DateOfReturn { get; set; }

        public override string ToString()
        {
            return $"{Author}: {Title}";
        }

        public Book()
        {
            IsBorrowed = false;
            NameOfBorrower = "No previous borrower";
            DateOfBorrowing = DateTime.MaxValue;
            DateOfReturn = DateTime.MaxValue;
        }
    }
}
