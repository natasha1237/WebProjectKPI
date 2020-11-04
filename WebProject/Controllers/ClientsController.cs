using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        ClientsContext db;
        public ClientsController(ClientsContext context)
        {
            db = context;
            if (!db.Clients.Any())
            {
                db.Clients.Add(new Client { Surname = "Goryanina", FirstName = "Natasha", Phone= "+380930602800", Email = "natasha@gmail.com" });
                db.Clients.Add(new Client { Surname = "Boichun", FirstName = "Sonya", Phone= "+380931111111", Email = "sonya@gmail.com" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await db.Clients.ToListAsync();
        }

        // GET api/clients
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            Client client = await db.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        // POST api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            // обработка частных случаев валидации

            if (client.FirstName == "admin")
            {
                ModelState.AddModelError("FirstName", "Inadmissible firstname - admin");
            }
            // если есть oшибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           /* if (client == null)
            {
                return BadRequest();
            }*/

            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        // PUT api/clients/
        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (!db.Clients.Any(x => x.Id == client.Id))
            {
                return NotFound();
            }

            db.Update(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(int id)
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }
        /*[HttpGet]
        [FormatFilter]
        public IEnumerable<Client> GetList()
        {
            return db.Clients.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteId(int id)
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            db.Clients.Remove(client);
            db.SaveChanges();
            return Ok(client);
        }*/
    }
}
