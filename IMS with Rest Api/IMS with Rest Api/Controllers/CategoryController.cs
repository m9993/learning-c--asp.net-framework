using IMS_with_Rest_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS_with_Rest_Api.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        InventoryDataContext context = new InventoryDataContext();

        //[HttpGet]
        //public IHttpActionResult AllCategories()
        //{
        //    return Ok(context.Categories.ToList());
        //}

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(context.Categories.ToList());
        }
        [Route("{id}",Name ="GetById")]
        public IHttpActionResult Get(int id)
        {
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(category);
        }

        [Route("")]
        public IHttpActionResult Post(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            string url = Url.Link("GetById",new { id=category.CategoryId});
            return Created(url,category);
        }
        [Route("{id}"),HttpPut]
        public IHttpActionResult Edit([FromBody]Category category,[FromUri]int id)
        {
            category.CategoryId = id;
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(category);
        }

        [Route("{id}"), HttpDelete]
        public IHttpActionResult Remove([FromUri] int id)
        {

            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
