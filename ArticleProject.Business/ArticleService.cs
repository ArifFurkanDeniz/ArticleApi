using ArticleProject.Business.Interfaces;
using ArticleProject.Entities.Models;
using ArticleProject.Repository.Generic;
using ArticleProject.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using ArticleProject.Domain.Dto;
using ArticleProject.Repository.Extensions;
using System.Linq;

namespace ArticleProject.Business
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _ArticleRepository;


        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IRepository<Article> ArticleRepository, IUnitOfWork unitOfWork)
        {
            _ArticleRepository = ArticleRepository;
        
            _unitOfWork = unitOfWork;
        }

        public ArticleDto GetById(int ArticleId)
        {
            var ArticleEntity = _ArticleRepository.GetById(ArticleId);

            return new ArticleDto
            {
                Id = ArticleEntity.Id,
                Title = ArticleEntity.Title,
                Text = ArticleEntity.Text,
                CategoryId = ArticleEntity.CategoryId,
                CreatedDate = ArticleEntity.CreatedDate,
                ModifiedDate = ArticleEntity.ModifiedDate
                
            };
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            var ArticleList = _ArticleRepository.Find();

            return ArticleList.Select(x => new ArticleDto
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            });
        }

       

        public void SaveArticle(ArticleDto Article)
        {
            var ArticleEntity = new Article
            {
                 Title = Article.Title,
                 Text = Article.Text,
                 CategoryId = Article.CategoryId
            };

            _ArticleRepository.Create(ArticleEntity);

            _unitOfWork.Commit();

        }

    }
}
