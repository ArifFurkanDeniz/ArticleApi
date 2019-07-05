using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleProject.Business.Interfaces;
using ArticleProject.Domain.Api;
using ArticleProject.Domain.Common;
using ArticleProject.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Api.Controllers
{
 
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET api/article
        [HttpGet]
        public ActionResult Get()
        {
            return OkResponse(_articleService.GetArticles());
        }

        // GET api/article/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var data = _articleService.GetById(id);
            if (data!=null)
            {
                return OkResponse(data);
            }
            else
            {
                return BadResponse(ResultModel.Error("Makale bulunamadı."));
            }
            
        }

        // GET api/article/search
        [HttpGet("search/{keyword}")]
        public ActionResult Search(string keyword)
        {
            return OkResponse(_articleService.Search(keyword));

        }

        // POST api/article
        [HttpPost]
        public ActionResult Post([FromBody] NewArticleApiRequest model)
        {

            var result = _articleService.SaveArticle(new ArticleDto()
            {
                Title = model.Title,
                Text = model.Text,
                CategoryId = model.CategoryId
            });


            if (result.Status)
            {
                return OkResponse(result);
            }
            else
            {
                return BadResponse(result);
            }
            
            
        }

        // PUT api/article/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NewArticleApiRequest model)
        {
            var result = _articleService.SaveArticle(new ArticleDto()
            {
                Id = id,
                Title = model.Title,
                Text = model.Text,
                CategoryId = model.CategoryId
            });


            if (result.Status)
            {
                return OkResponse(result);
            }
            else
            {
                return BadResponse(result);
            }

        }

        // DELETE api/article/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var result = _articleService.DeleteArticle(id);

            if (result.Status)
            {
                return OkResponse(result);
            }
            else
            {
                return BadResponse(result);
            }

        }
    }
}