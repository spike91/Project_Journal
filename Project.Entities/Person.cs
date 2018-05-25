using System.Collections.Generic;

namespace Project.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PersonroleID { get; set; }
        public Personrole Personrole { get; set; }

        public ICollection<PersonJournalarticle> PersonJournalarticles { get; set; }
    }
}
