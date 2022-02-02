using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class Answer
    {
        public Answer()
        {
            AnswerComments = new HashSet<AnswerComment>();
        }

        public int PId { get; set; }
        public int? QId { get; set; }

        public virtual Post PIdNavigation { get; set; }
        public virtual Question QIdNavigation { get; set; }
        public virtual ICollection<AnswerComment> AnswerComments { get; set; }
    }
}
