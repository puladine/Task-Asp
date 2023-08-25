using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = String.Empty;
        [Required]
        public string Lastname { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تلفن باید 11 رقم باشد")]
        public string PhoneNumber { get; set; } = String.Empty;
        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string BankAccountNumber { get; set; } = string.Empty;
    }
}
