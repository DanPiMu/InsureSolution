using InsureCompany.ApplicationService.Service;
using Microsoft.AspNetCore.Mvc;

namespace InsureCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(string id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpGet("byName/{name}")]
        public async Task<IActionResult> GetClientByName(string name)
        {
            var client = await _clientService.GetClientByNameAsync(name);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}
