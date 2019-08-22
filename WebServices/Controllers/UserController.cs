using System.Collections.Generic;
using DataTier;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _userRepository.GetUser(id);
        }

        // POST: api/User
        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userRepository.Add(user);
        }

        // PUT: api/User/5
        [HttpPut]
        public User Put([FromBody] User user)
        {
            return _userRepository.Update(user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
