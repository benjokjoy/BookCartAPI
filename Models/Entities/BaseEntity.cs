using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class BaseEntity
    {
        [Key]   
        public long Id
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime ? UpdatedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
