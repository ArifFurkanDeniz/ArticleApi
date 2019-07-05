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
 
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

     
        // POST api/comment
        [HttpPost]
        public ActionResult Post([FromBody] NewCommentApiRequest model)
        {
            Log.Logger.Information("CommentController - Post Logged");

            var result = _commentService.SaveComment(new ArticleCommentDto()
            {
                Email = model.Email,
                Text = model.Text,
                ArticleId = model.ArticleId
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

        // PUT api/comment/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NewCommentApiRequest model)
        {
            Log.Logger.Information("CommentController - Put Logged");

            var result = _commentService.SaveComment(new ArticleCommentDto()
            {
                Id = id,
                Email = model.Email,
                Text = model.Text,
                ArticleId = model.ArticleId
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

        // DELETE api/comment/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Log.Logger.Information("CommentController - Delete Logged");

            var result = _commentService.DeleteComment(id);

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