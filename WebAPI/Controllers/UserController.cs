using AutoMapper;
using meeting.core.Models;
using meeting.services.Interfaces;
using meeting.services.Resources;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.FluentValidation;
using ServiceStack.Validation;
using Web_API.Validators;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Resources.UserResources>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<meeting.core.Models.User>, IEnumerable<Resources.UserResources>>(users);

            return Ok(userResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resources.UserResources>> GetUserById(string id)
        {
            var users = await _userService.GetUserById(id);
            var userResource = _mapper.Map<meeting.core.Models.User, Resources.UserResources>(users);

            return Ok(userResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<Resources.UserResources>> CreateUser([FromBody] SaveUserResources SaveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(SaveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var userToCreate = _mapper.Map<SaveUserResources, meeting.core.Models.User>(SaveUserResource);

            var newUser = await _userService.CreateUser(userToCreate);

            var user = await _userService.GetUserById(newUser.Id);
            var userResource = _mapper.Map<meeting.core.Models.User, UserResources>(user);
            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResources>> UpdateUser(string id, [FromBody] SaveUserResources saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            var requestIsInvalid = id == "0" || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var userToBeUpdate = await _userService.GetUserById(id);

            if (userToBeUpdate == null)
                return NotFound();

            var user = _mapper.Map<SaveUserResources, meeting.core.Models.User>(saveUserResource);

            await _userService.UpdateUser(userToBeUpdate, user);

            var updatedUser = await _userService.GetUserById(id);
            var updatedUserResource = _mapper.Map<meeting.core.Models.User, UserResources>(updatedUser);

            return Ok(updatedUserResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == "0")
                return BadRequest();

            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            await _userService.DeleteUser(user);

            return NoContent();
        }
    }
}
