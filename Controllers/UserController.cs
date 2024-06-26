using AutoMapper;
using InfinionAPI.DTO;
using InfinionAPI.Interface;
using InfinionAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfinionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        private readonly IMapper _mapper;
        public UserController(IUserInterface userInterface, IMapper mapper)
        {
            _userInterface= userInterface;
            _mapper= mapper;    
        }

        [Authorize]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users= await _userInterface.GetUsersAsync();
            if (users == null)
            {
                return NotFound();

            }

            return Ok(users);
        }

        [Authorize]

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUsersById(int id)
        {
            var userId = await _userInterface.GetUsersById(id);
            if (userId == null)
            {
                return NotFound();
            }
            return Ok(userId);
        }

        [Authorize]
        [HttpDelete]

        [Route("{id:int}", Name = "Delete")]

        public async Task< IActionResult> DeleteUsers(int id) 
        {
            var userId = await _userInterface.DeleteUsers(id);
           if (userId == null)
            {
                return NotFound();
            }
            return Ok(userId);
        }

        [Authorize]
        [HttpPost ("CreateUser")]

        public async Task<IActionResult> CreateUser([FromBody]CreateUserDTO createUser)
        {

            var mapNewUser = _mapper.Map<Users>(createUser);
            await  _userInterface.CreateUsers(mapNewUser);

            return Ok(mapNewUser);
        }
        [Authorize]
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody]UpdateUserDTO updateUser)
        {
            var mappedUser = _mapper.Map<Users>(updateUser);
            var UserId = await _userInterface.UpdateUSers(id, mappedUser);

            if (UserId == null) { 
                return NotFound();
            }

            UserId.FirstName = mappedUser.FirstName;
            UserId.LastName = mappedUser.LastName;
            UserId.EmailAddress= mappedUser.EmailAddress;
            UserId.Password= mappedUser.Password;
            
               _mapper.Map<UserDTO>(mappedUser);
            return Ok(mappedUser);
        }

    }
}
