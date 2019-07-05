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
    public class CommentService : ICommentService
    {
        private readonly IRepository<ArticleComments> _ArticleCommentRepository;
        private readonly IRepository<Article> _ArticleRepository;


        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IRepository<ArticleComments> ArticleCommentRepository, IRepository<Article> ArticleRepository, IUnitOfWork unitOfWork)
        {
            _ArticleCommentRepository = ArticleCommentRepository;
            _ArticleRepository = ArticleRepository;

            _unitOfWork = unitOfWork;
        }

        public ResultModel SaveComment(ArticleCommentDto ArticleComment)
        {
            var article = _ArticleRepository.GetById(ArticleComment.ArticleId);

            if (article==null)
            {
                return new ResultModel(false, "Makale bulunamadı.");
            }

            if (ArticleComment.Id>0)
            {
                var ArticleEntity = new ArticleComments
                {
                    Id = ArticleComment.Id,
                    Email = ArticleComment.Email,
                    Text = ArticleComment.Text,
                    ArticleId = ArticleComment.ArticleId
                };

                _ArticleCommentRepository.Update(ArticleEntity);       
            }
            else
            {
                var ArticleEntity = new ArticleComments
                {
                    Email = ArticleComment.Email,
                    Text = ArticleComment.Text,
                    ArticleId = ArticleComment.ArticleId
                };

                _ArticleCommentRepository.Create(ArticleEntity);
            }
           

            return _unitOfWork.Commit();

        }

        public ResultModel DeleteComment(int articleCommentId)
        {
            var data = _ArticleCommentRepository.GetById(articleCommentId);

            if (data==null)
            {
                return new ResultModel(false, "Yorum bulunamadı.");
            }

            _ArticleCommentRepository.Delete(data);

            return _unitOfWork.Commit();
        }
    }
}
