using Model;
using DataTier;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _userRepository.GetAllUsers();

            if(users == null)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        // GET api/user/1
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedUser = _userRepository.Add(user);
            return CreatedAtAction("Get", new { id = addedUser.Id }, addedUser);
        }

        // DELETE api/user/1
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingItem = _userRepository.GetUserById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _userRepository.Remove(id);

            return Ok();
        }
    }
}
