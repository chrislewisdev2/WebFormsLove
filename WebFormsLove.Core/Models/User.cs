namespace WebFormsLove.Core.Models
{
    using System;
    using WebFormsLove.Core.Validation;

    public class User
    {
        public Guid Id { get; set; }

        [RegularExpression("^[A-Za-z]{2,10}$", ErrorMessage = "Please enter a valid first name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Za-z\-]{2,10}$", ErrorMessage = "Please enter a valid last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Please enter a valid phone number")]
        [Required(ErrorMessage = "Telephone number is required")]
        public string TelephoneNumber { get; set; }
    }
}