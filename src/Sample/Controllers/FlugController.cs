using DataAccessLayer;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    public class FlugController: Controller
    {
        // Not RESTful, but pragmatic!
        [HttpGet("byRoute")]
        public List<Flug> GetByRoute(string von, string nach) {
            var flugManager = new FlugManager();
            return flugManager.FindByRoute(von, nach);
        }

        [HttpGet]
        public List<Flug> GetAll() {
            var flugManager = new FlugManager();
            return flugManager.FindAll();
        }

        [HttpGet("{id}")]
        public Flug GetById(int id) {
            var flugManager = new FlugManager();
            return flugManager.FindById(id);
        }

        [HttpPost]
        public void PostFlug([FromBody] Flug flug) {
            var flugManager = new FlugManager();
            flugManager.Create(flug);
        }

        [HttpPut]
        [AcceptVerbs("UPDATE")]
        public void PutFlug([FromBody] Flug flug) {
            var flugManager = new FlugManager();
            flugManager.Update(flug);
        }
    }
}
