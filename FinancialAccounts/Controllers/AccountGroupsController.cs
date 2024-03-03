using FinancialAccounts.Interfases;
using FinancialAccounts.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountGroupsController : ControllerBase
    {
        private readonly IAccountGroupInterface _groupService;

        public AccountGroupsController(IAccountGroupInterface groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountGroup>>> GetGroups()
        {
            return Ok(await _groupService.GetGroupsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountGroup>> GetGroup(Guid id)
        {
            var group = await _groupService.GetGroupAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return group;
        }

        [HttpPost]
        public async Task<ActionResult<AccountGroup>> CreateGroup(AccountGroup group)
        {
            var createdGroup = await _groupService.CreateGroupAsync(group);
            return Ok(createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(Guid id, AccountGroup group)
        {
            await _groupService.UpdateGroupAsync(id, group);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            await _groupService.DeleteGroupAsync(id);
            return NoContent();
        }
    }
}
