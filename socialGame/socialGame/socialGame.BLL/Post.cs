using System;
using System.Collections.Generic;
using System.Text;

namespace socialGame.BLL
{
    public class Post
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
