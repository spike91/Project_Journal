using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Project.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
