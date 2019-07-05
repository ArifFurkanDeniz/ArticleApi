using ArticleProject.Domain.Common;
using ArticleProject.Domain.Dto;
using ArticleProject.Entities.Models;
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
        /// Makale içinde string olarak arama yapar
        /// </summary>
        /// <param name="keyword">Arancak kelime</param>
        /// <returns></returns>
        IEnumerable<ArticleDto> Search(string keyword);

        /// <summary>
        /// Makale listesini getirir
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArticleDto> GetArticles();


        /// <summary>
        /// Yeni bir makale kayıt eder
        /// </summary>
        /// <param name="Article">Makale dto modeli</param>
        ResultModel SaveArticle(ArticleDto Article);

        /// <summary>
        /// Bir makale siler
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        ResultModel DeleteArticle(int articleId);
    }
}
