using System;
using System.Collections.Generic;

namespace ArticleProject.Entities.Models
{
    public partial class ArticleComments : BaseEntity
    {

        public string Email { get; set; }
        public string Text { get; set; }
        public int ArticleId { get; set; }


        public virtual Article Article { get; set; }
    }
}
