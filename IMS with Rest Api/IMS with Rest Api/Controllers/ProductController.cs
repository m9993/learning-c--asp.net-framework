using IMS_with_Rest_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS_with_Rest_Api.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        InventoryDataContext context = new InventoryDataContext();


        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(context.Products.ToList());
        }
        [Route("{id}",Name = "GetByProductId")]
        public IHttpActionResult Get(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(product);
        }

        [Route("")]
        public IHttpActionResult Post(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            string url = Url.Link("GetByProductId",new { id= product.ProductId});
            return Created(url,product);
        }
        [Route("{id}"),HttpPut]
        public IHttpActionResult Edit([FromBody] Product product, [FromUri]int id)
        {
            product.ProductId = id;
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(product);
        }

        [Route("{id}"), HttpDelete]
        public IHttpActionResult Remove([FromUri] int id)
        {

            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
