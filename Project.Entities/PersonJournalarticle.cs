using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class PersonJournalarticle
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int JournalarticleID { get; set; }
        public Journalarticle Journalarticle { get; set; }
    }
}
