using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string LastName { get; set; }

        [RegularExpression(@"^((\d{3})(\d{3})(\d{2})(\d{2}))$",
         ErrorMessage = "Please write your phone number without 0 at the beginning.")]
        public string PhoneNumber { get; set; }
    }
}
