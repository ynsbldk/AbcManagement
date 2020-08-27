using System;
using System.Collections.Generic;
using System.Text;

namespace AbcManagement.Entities.Entities
{
    public class Log : BaseEntity, IEntity
    {
        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        public string Level { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }
    }
}
