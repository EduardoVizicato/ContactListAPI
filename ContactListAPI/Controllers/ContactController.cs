using ContactList.Domain.Data.Models;
using ContactList.Domain.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController (IContactRepository repository) : ControllerBase
    {
        private readonly IContactRepository _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var data =  await _repository.GetAll();

            if(data.Count == 0)
            {
                return NoContent();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _repository.GetById(id);

            if(data == null)
            {
                return NotFound();
            }

            return Ok(data);

        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] Contact request)
        {
            var contactId = await _repository.Add(request);

            return CreatedAtAction(nameof(GetAll), new { Id = contactId }, request);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id, Contact contact)
        {
            var deleted = await _repository.Delete(id, contact);
            if (deleted == null)
            {
                return NotFound();
            }
            if (!deleted.Value)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromBody] Contact request)
        {
            var updated = await _repository.Update(id, request);

            if(updated == null)
            {
                return NotFound();
            }

            if (!updated.Value)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
