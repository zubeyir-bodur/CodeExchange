using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class Post
    {
        public int PId { get; set; }
        public string Username { get; set; }
        public string Body { get; set; }
        public int? Votes { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Question Question { get; set; }
    }
}
