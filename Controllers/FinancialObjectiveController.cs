using Microsoft.AspNetCore.Mvc;
using SavingsDev.API.Entities;
using SavingsDev.API.Models;
using SavingsDev.API.Persistence;

namespace SavingsDev.API.Controllers
{
    [ApiController]
    [Route("api/financial-objective")]
    public class FinancialObjectiveController : ControllerBase
    {
        private readonly Context _context;

        public FinancialObjectiveController(Context context)
        {
            _context = context;
        }

        // GET api/financial-objective
        [HttpGet]
        public IActionResult GetAll()
        {
            var objectives = _context.Objectives;
            return Ok(objectives);
        }

        // GET api/financial-objective/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var objective = _context.Objectives.SingleOrDefault(obj => obj.Id == id);
            if (objective == null)
            {
                return NotFound();
            }

            return Ok(objective);
        }

        // POST api/financial-objective
        [HttpPost]
        public IActionResult Post(FinancialObjectiveInputModel model)
        {
            var objective = new FinancialObjective(model.title, model.description, model.valueObject);

            _context.Objectives.Add(objective);

            var id = objective.Id;

            return CreatedAtAction("GetById", new { id = id }, model);
        }

        // POST api/financial-objective/id/operations
        [HttpPost("{id}/operations")]
        public IActionResult PostOperation(int id, OperationInputModel model)
        {
            var operation = new Operation(model.Value, model.Type);

            var objective = _context.Objectives.SingleOrDefault(obj => obj.Id == id);
            if (objective == null)
            {
                return NotFound();
            }

            objective.PerformOperation(operation);

            return NoContent();
        }
    }
}