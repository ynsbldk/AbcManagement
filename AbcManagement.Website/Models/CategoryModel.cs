using AbcManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbcManagement.Website.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public int ProjectId { get; set; }   

        public Project Project { get; set; }
    }
}
