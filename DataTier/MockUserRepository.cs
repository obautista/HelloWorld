using Model;
using System.Linq;
using System.Collections.Generic;

namespace DataTier
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>()
            {
                new User() { Id = 1, FirstName = "Clark", LastName = "Kent" },
                new User() { Id = 2, FirstName = "Peter", LastName = "Parker" },
                new User() { Id = 3, FirstName = "Tony", LastName = "Stark" }
            };
        }

        public User Add(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);
            return user;
        }

        public User Remove(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                _users.Remove(user);
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User Update(User userChanges)
        {
            var user = _users.FirstOrDefault(u => u.Id == userChanges.Id);
            if (user != null)
            {
                user.FirstName = userChanges.FirstName;
                user.LastName = userChanges.LastName;
            }
            return user;
        }
    }
}
