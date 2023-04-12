using CdcApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CdcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InController : ControllerBase
    {
        private readonly DatabaseContext dbContext;
        public InController(DatabaseContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        // GET: api/<InController>
        [HttpGet]
        public IEnumerable<Contract> Get()
        {
            return dbContext.Contracts.OrderBy(x => x.Id).ToList();
        }
        // POST api/<InController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var maxId = dbContext.Contracts.Max(x=>x.Id);
            var contract = new Contract {Name=$"Name{maxId+1}" };

            dbContext.Contracts.Add(contract);
            dbContext.SaveChanges();
        }
    }
}
