using System;
using System.Collections.Generic;

namespace ArticleProject.Entities.Models
{
    public partial class Article : BaseEntity
    {
        public Article()
        {
            ArticleComments = new HashSet<ArticleComments>();
        }

  
        public string Title { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
    

        public virtual ArticleCategory Category { get; set; }
        public virtual ICollection<ArticleComments> ArticleComments { get; set; }
    }
}
