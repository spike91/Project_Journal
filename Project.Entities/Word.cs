using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Word
    {
        public int WordID { get; set; }
        public string Name { get; set; }

        public ICollection<KeyWord> KeyWords { get; set; }
    }
}
