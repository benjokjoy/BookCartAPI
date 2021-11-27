using System;
using System.ComponentModel.DataAnnotations;

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
