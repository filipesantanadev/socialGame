using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace socialGame.BLL
{
    public class User : IdentityUser
    {
        /*[ForeignKey("IdentityUser")]
        public string Id { get; set; }*/

        [PersonalData]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [PersonalData]
        [DisplayName("Password")]
        [RegularExpression("^(?=.[a-z])(?=.[A-Z])(?=.*\\d)(?=.[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Senha não atende os requisitos")]
        public string Password { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public bool TermsAccepted { get; set; }
    }
}
