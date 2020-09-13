using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace socialGame.BLL
{
    public class Friendship
    {
        public Guid UserIdA { get; set; }
        public Guid UserIdB { get; set; }
        public ApplicationUser UserA { get; set; }
        public ApplicationUser UserB { get; set; }
    }
}