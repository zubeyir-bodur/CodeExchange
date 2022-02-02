using System;
using System.Collections.Generic;

#nullable disable

namespace CodeExchangeEntity
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            QuestionComments = new HashSet<QuestionComment>();
        }

        public int PId { get; set; }
        public string Header { get; set; }

        public virtual Post PIdNavigation { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QuestionComment> QuestionComments { get; set; }
    }
}
