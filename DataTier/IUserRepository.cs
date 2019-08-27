using Model;
using System.Collections.Generic;

namespace DataTier
{
    public interface IUserRepository
    {
        User GetUserById(int id);

        IEnumerable<User> GetAllUsers();

        User Add(User user);

        User Update(User userChanges);

        User Remove(int id);
    }
}
