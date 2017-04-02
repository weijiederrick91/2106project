using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//i change here 2
namespace Team11_2106Project.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [Display(Name = "Select Your Role")]
        [Required]
        public StudentRole StudentRole { get; set; }

      
    }
  
}
public enum StudentRole
{
    Admin,
    Voter,
    Candidate
}