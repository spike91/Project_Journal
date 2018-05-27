using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<ConcretejournalComment> ConcretejournalComments { get; set; }
    }
}
