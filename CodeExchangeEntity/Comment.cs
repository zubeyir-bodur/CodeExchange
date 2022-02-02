using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class Comment
    {
        public int PId { get; set; }

        public virtual Post PIdNavigation { get; set; }
        public virtual AnswerComment AnswerComment { get; set; }
        public virtual QuestionComment QuestionComment { get; set; }
    }
}
