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
using Serilog;

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
            Log.Logger.Information("ArticleController - Get Logged");
            return OkResponse(_articleService.GetArticles());
        }

        // GET api/article/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Log.Logger.Information("ArticleController - Get Logged");
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
            Log.Logger.Information("ArticleController - Search Logged");
            return OkResponse(_articleService.Search(keyword));

        }

        // POST api/article
        [HttpPost]
        public ActionResult Post([FromBody] NewArticleApiRequest model)
        {
            Log.Logger.Information("ArticleController - Post Logged");
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
            Log.Logger.Information("ArticleController - Put Logged");
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
            Log.Logger.Information("ArticleController - Delete Logged");
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