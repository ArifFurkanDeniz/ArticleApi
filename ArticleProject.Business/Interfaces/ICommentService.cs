using ArticleProject.Domain.Common;
using ArticleProject.Domain.Dto;
using ArticleProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Business.Interfaces
{
    public interface ICommentService
    {

        /// <summary>
        /// Yeni bir yorum kayıt eder
        /// </summary>
        /// <param name="ArticleComment">Makale yorumu dto modeli</param>
        ResultModel SaveComment(ArticleCommentDto ArticleComment);

        /// <summary>
        /// Bir yorum siler
        /// </summary>
        /// <param name="articleCommentId">Makale yorumu</param>
        /// <returns></returns>
        ResultModel DeleteComment(int articleCommentId);
    }
}
