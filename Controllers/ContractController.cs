using System.Collections.Generic;
using System.Threading.Tasks;
using ContratosApi.Data;
using ContratosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosApi.Controllers
{
    [ApiController]
    [Route("v1/contracts")]
    public class ContractController : ControllerBase
    {
        private readonly DataContext _context;

        public ContractController (DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contract>>> Get ()
        {
            var contracts = await _context.Contracts.ToListAsync();

            return contracts;
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> Post([FromBody] Contract model)
        {
            if (ModelState.IsValid)
            {
                _context.Contracts.Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}