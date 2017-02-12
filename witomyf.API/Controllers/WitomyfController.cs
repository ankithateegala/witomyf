using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using witomyf.API.Models;

namespace witomyf.API.Controllers
{
    [Route("/api/[controller]")]
    public class WitomyfController : Controller
    {
        //GET api/witomyf
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/witomyf/5
        [HttpGet("{day}")]
        public Witomyf Get(string day)
        {
            return new Witomyf { Day = day, Eat1 = 50 };
        }

        // POST api/witomyf
        [HttpPost]
        public void Post([FromBody]Witomyf witomyf)
        {

        }

        // PUT api/witomyf/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/witomyf/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
