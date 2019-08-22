using Model;
using System.Collections.Generic;

namespace DataTier
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Update(User userChanges);
        User Delete(int id);
    }
}
