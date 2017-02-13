using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using witomyf.API.Models;
using witomyf.API.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace witomyf.API.Controllers
{
    [EnableCors("MyPolicy")]

    [Route("/api/[controller]")]
    public class WitomyfController : Controller
    {
        public readonly IDBHelper _DBHelper;

        public WitomyfController(IDBHelper DBHelper)
        {
            _DBHelper = DBHelper;
        }

        [HttpGet("{day}")]
        public Witomyf Get([FromRoute]string day)
        {
            return _DBHelper.GetWitomyf(day);
        }

        [HttpPost]
        public void Post([FromBody]Witomyf witomyf)
        {
            _DBHelper.InsertWitomyf(witomyf);
        }

        //GET api/witomyf
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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
