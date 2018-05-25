using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class KeyWord
    {
        public int WordID { get; set; }
        public Word Word { get; set; }
        public int JournalarticleID { get; set; }
        public Journalarticle Journalarticle { get; set; }
    }
}
