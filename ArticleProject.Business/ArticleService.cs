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
using ArticleProject.Domain.Common;

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
            var ArticleEntity = _ArticleRepository.GetById(ArticleId, x => x.Include(y => y.ArticleComments));

            if (ArticleEntity != null)
            {
                return new ArticleDto
                {
                    Id = ArticleEntity.Id,
                    Title = ArticleEntity.Title,
                    Text = ArticleEntity.Text,
                    CategoryId = ArticleEntity.CategoryId,
                    CreatedDate = ArticleEntity.CreatedDate,
                    ModifiedDate = ArticleEntity.ModifiedDate,
                    ArticleComment = ArticleEntity.ArticleComments.Select(x=> new ArticleCommentDto()
                    {
                        ArticleId = x.ArticleId,
                        CreatedDate = x.CreatedDate,
                        Email = x.Email,
                        Id = x.Id,
                        ModifiedDate = x.ModifiedDate,
                        Text = x.Text
                    })

                };
            }
            else
                return null;
           
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            var ArticleList = _ArticleRepository.Find(null, x => x.Include(y => y.ArticleComments));

            return ArticleList.Select(x => new ArticleDto
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                ArticleComment = x.ArticleComments.Select(y => new ArticleCommentDto()
                {
                    ArticleId = y.ArticleId,
                    CreatedDate = y.CreatedDate,
                    Email = y.Email,
                    Id = y.Id,
                    ModifiedDate = y.ModifiedDate,
                    Text = y.Text
                })
            });
        }

       

        public ResultModel SaveArticle(ArticleDto Article)
        {
            if (Article.Id>0)
            {
                var ArticleEntity = new Article
                {
                    Id = Article.Id,
                    Title = Article.Title,
                    Text = Article.Text,
                    CategoryId = Article.CategoryId
                };

                _ArticleRepository.Update(ArticleEntity);       
            }
            else
            {
                var ArticleEntity = new Article
                {
                    Title = Article.Title,
                    Text = Article.Text,
                    CategoryId = Article.CategoryId
                };

                _ArticleRepository.Create(ArticleEntity);
            }
           

            return _unitOfWork.Commit();

        }

        public ResultModel DeleteArticle(int articleId)
        {
            var data = _ArticleRepository.GetById(articleId);

            if (data==null)
            {
                return new ResultModel(false, "Makale bulunamadı.");
            }

            _ArticleRepository.Delete(data);

            return _unitOfWork.Commit();
        }

        public IEnumerable<ArticleDto> Search(string keyword)
        {
            var ArticleList = _ArticleRepository.Find(x => x.Title.Contains(keyword) || x.Text.Contains(keyword));

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
    }
}
