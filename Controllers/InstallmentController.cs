using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContratosApi.Data;
using ContratosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosApi.Controllers {
    [ApiController]
    [Route ("v1/installments")]
    public class InstallmentController : ControllerBase {

        private readonly DataContext _context;

        public InstallmentController (DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Installment>>> Get () {
            var installments = await _context.Installments
                .Include (x => x.Contract)
                .ToListAsync ();

            return installments;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Installment>> GetById (int id) {
            var installment = await _context.Installments
                .Include (x => x.Contract)
                .AsNoTracking ()
                .FirstOrDefaultAsync (x => x.Id == id);

            return installment;
        }

        [HttpGet ("contracts/{id}")]
        public async Task<ActionResult<List<Installment>>> GetByContract (int id) {
            var installments = await _context.Installments
                .Include (x => x.Contract)
                .AsNoTracking ()
                .Where (x => x.ContractId == id)
                .ToListAsync ();

            return installments;
        }

        [HttpPost]
        public async Task<ActionResult<Installment>> Post ([FromBody] Installment model) {
            if (ModelState.IsValid) {
                _context.Installments.Add (model);
                await _context.SaveChangesAsync ();

                return model;
            } else {
                return BadRequest (ModelState);
            }
        }
    }
}