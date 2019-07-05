using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Domain.Api
{
    public class NewCommentApiRequest
    {
        public string Email { get; set; }
        public string Text { get; set; }
        public int ArticleId { get; set; }
    }
}
