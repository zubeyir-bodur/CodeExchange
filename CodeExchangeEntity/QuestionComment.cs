using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class QuestionComment
    {
        public int PId { get; set; }
        public int? QId { get; set; }

        public virtual Comment PIdNavigation { get; set; }
        public virtual Question QIdNavigation { get; set; }
    }
}
