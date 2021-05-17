using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesApi.Data;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {
        QuotesDbContext quotesDbContext = new QuotesDbContext();

        // GET: api/Quotes
        //public IEnumerable<Quote> Get()
        [HttpGet]
        [Route("api/Quotes/type/{search=}")]
        public IHttpActionResult search(string search)
        {
            IQueryable<Quote> quotes;
             quotes = quotesDbContext.Quotes.Where(a => a.Type == search);
                return Ok(quotes);

        }

        [HttpGet]
[Route("api/Quotes/filter/{order=}")]
         public IHttpActionResult filter(string order)
        {
            IQueryable quotes;
            switch (order) {
                case "desc":
                      quotes = quotesDbContext.Quotes.OrderByDescending(a => a.CreatedAt);
                    break;
                case "asc":
                     quotes = from s in quotesDbContext.Quotes
                     orderby s.CreatedAt ascending
                     select s;
                    break;
                default:
                    quotes = quotesDbContext.Quotes;
                    break;

            }
            return Ok(quotes);
            
        }
        [HttpGet]
        public IHttpActionResult Get()

        {
            return Ok(quotesDbContext.Quotes);
            //var query = from s in quotesDbContext.Quotes
            //orderby s.CreatedAt descending
            //select s;
            //return Ok(query);
        }

        // GET: api/Quotes/5
        [HttpGet]
        [Route("api/Quotes/custom/{id}")]
        public Quote customfunciton(int id)
        {
            return quotesDbContext.Quotes.SingleOrDefault(a=>a.Id==id+1);
        }
        [HttpGet]
        
        public IHttpActionResult Get(int id)
        {
            //return quotesDbContext.Quotes.Find(id);
            var quote = quotesDbContext.Quotes.FirstOrDefault(a => a.Id == id);
            if (quote == null){
                return BadRequest("Id not found");
            }
            return Ok(quote);
           // return quotesDbContext.Quotes.SingleOrDefault(a => a.Id == id);
        }

        // POST: api/Quotes
        [HttpPost]
        public IHttpActionResult Post([FromBody]Quote value)
        {
            quotesDbContext.Quotes.Add(value);
            quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Quote value)
        {
            //var tempquote = quotesDbContext.Quotes.SingleOrDefault(a => a.Id == id);
            var tempquote = quotesDbContext.Quotes.FirstOrDefault(a => a.Id == id);
            if (tempquote == null)
            {
                return BadRequest("Data not found");
            }
            tempquote.Author = value.Author;
            tempquote.Description = value.Description;
            tempquote.Title = value.Title;


            quotesDbContext.SaveChanges();
            return Ok("Record updated successfully");

        }

        // DELETE: api/Quotes/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var tempquote = quotesDbContext.Quotes.FirstOrDefault(a => a.Id == id);
            if(tempquote == null)
            {
                return BadRequest("Record Not found");
            }
            quotesDbContext.Quotes.Remove(tempquote);
            quotesDbContext.SaveChanges();
            return Ok("Record deleted successfully");
        }
    }
}
