using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class AnswerComment
    {
        public int PId { get; set; }
        public int? AId { get; set; }

        public virtual Answer AIdNavigation { get; set; }
        public virtual Comment PIdNavigation { get; set; }
    }
}
