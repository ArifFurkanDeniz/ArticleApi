using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Domain.Api
{
    public class NewArticleApiRequest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
    }
}
