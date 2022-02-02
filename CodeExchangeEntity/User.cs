using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
