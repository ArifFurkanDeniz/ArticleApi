using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Entities.Models
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
