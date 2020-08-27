using System;
using System.Collections.Generic;
using System.Text;

namespace AbcManagement.Entities.Entities
{    
    public class Category :BaseEntity, IEntity
    {
        public int ProjectId { get; set; }

        public string CategoryName { get; set; }

        public Project Project { get; set; }
        
    }
}
