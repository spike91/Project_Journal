using System.Collections.Generic;

namespace Project.Entities
{
    public class Personrole
    {
        public int PersonroleID { get; set; }
        public string RoleName { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
