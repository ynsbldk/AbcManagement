using AbcManagement.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AbcManagement.Website.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public double Progress { get; set; }

        public string Icon { get; set; }       

        public int CategoryId { get; set; }

        public ApplicationUser AppUser { get; set; }

        public string AppUserId { get; set; }

    }

    public class UserProject
    {
        public IEnumerable<ApplicationUser> myUser { get; set; }

        public IEnumerable<ProjectModel> myProject { get; set; }
    }
}
