using ArticleProject.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Business.Interfaces
{
    public interface IArticleService
    {
      /// <summary>
      /// Tekil makale döndürür
      /// </summary>
      /// <param name="articleId">Makalenin Id'si</param>
      /// <returns></returns>
        ArticleDto GetById(int articleId);

        /// <summary>
        /// Makale listesini getirir
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArticleDto> GetArticles();


        /// <summary>
        /// Yeni bir makale kayıt eder
        /// </summary>
        /// <param name="Article">Makale dto modeli</param>
        void SaveArticle(ArticleDto Article);
    }
}
