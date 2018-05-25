using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class ConcretejournalComment
    {
        public int ConcretejournalID { get; set; }
        public Concretejournal Concretejournal { get; set; }
        public int CommentID { get; set; }
        public Comment Comment { get; set; }
    }
}
