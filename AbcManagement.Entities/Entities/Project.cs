using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace AbcManagement.Entities.Entities
{    
    public class Project : BaseEntity, IEntity
    {             

        public string ProjectName { get; set; }

        public double Progress { get; set; }

        public string Icon { get; set; }

        public Category Category { get; set; }

     



    }
}
