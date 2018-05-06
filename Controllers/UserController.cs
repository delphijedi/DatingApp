using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class UserController: Controller
    {
        private readonly IDatingInterface _repo;
        private readonly IMapper _mapper;

        public UserController(IDatingInterface repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await  _repo.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListsDto>>(users);
            return Ok(usersToReturn);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id )
        {
            var user = await _repo.GetUserAsync(id);
            var userToReturn = _mapper.Map<UserForDetailDto>(user);
            return Ok(userToReturn);
            
        }
    }
}