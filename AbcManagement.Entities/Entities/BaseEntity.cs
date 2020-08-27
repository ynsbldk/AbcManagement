using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace AbcManagement.Entities.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ApplicationUser AppUser { get; set; }

        public string AppUserId { get; set; }

    }
}
