using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcManagement.Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {      
        public List<Project> Projects { get; set; }

        public List<Category> Categories { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}
