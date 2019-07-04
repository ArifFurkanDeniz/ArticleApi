using System;
using System.Collections.Generic;

namespace ArticleProject.Entities.Models
{
    public partial class ArticleCategory : BaseEntity
    {
        public ArticleCategory()
        {
            Article = new HashSet<Article>();
        }

        public string Title { get; set; }
      

        public virtual ICollection<Article> Article { get; set; }
    }
}
