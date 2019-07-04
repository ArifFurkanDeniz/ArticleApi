using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Domain.Dto
{
    public class ArticleDto : BaseDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }

    }
}
