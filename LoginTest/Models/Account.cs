using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginTest.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Username is Required.")]
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [Display(Name = "E-Mail: ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [NotMapped]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-Password is Required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm-Password have to be the same.")]
        [Display(Name = "Confirm Password: ")]
        public string ConfirmPassword { get; set; }
        
        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}