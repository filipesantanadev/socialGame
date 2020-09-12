using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace socialGame.BLL
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [DisplayName("Last Name")]
        public string LastName { get; set; }        

        [PersonalData]
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        /*public ICollection<Friendship> FriendshipA { get; set; }
        public ICollection<Friendship> FriendshipB { get; set; }*/

        /*[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public bool TermsAccepted { get; set; }*/
    }
}
