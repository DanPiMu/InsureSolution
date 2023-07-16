using InsureCompany.ApplicationService.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace InsureCompany.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/Client/[controller]")]
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
                Log.Error($"Client not found by ID: {id}");
                return NotFound();
            }
            Log.Information($"Student finded by ID: {id}");
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
