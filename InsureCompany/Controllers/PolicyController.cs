using InsureCompany.ApplicationService.Service;
using Microsoft.AspNetCore.Mvc;

namespace InsureCompany.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/Policy/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly IClientService _clientService;

        public PolicyController(IPolicyService policyService, IClientService clientService)
        {
            _policyService = policyService;
            _clientService = clientService;
        }

        [HttpGet("byUserName/{name}")]
        public async Task<IActionResult> GetPoliciesByUserName(string name)
        {
            var policies = await _policyService.GetPoliciesByUserNameAsync(name);

            if (policies == null)
            {
                return NotFound();
            }

            return Ok(policies);
        }

        [HttpGet("byPolicyNumber/{policyNumber}")]
        public async Task<IActionResult> GetClientByPolicyNumber(string policyNumber)
        {
            var client = await _clientService.GetClientByPolicyNumberAsync(policyNumber);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}
