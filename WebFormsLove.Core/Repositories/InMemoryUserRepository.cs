using System;
using System.Collections.Generic;
using System.Linq;

namespace WebFormsLove.Core.Repositories
{
    using WebFormsLove.Core.Models;
    using WebFormsLove.Helpers;

    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly IList<User> Users;

        static InMemoryUserRepository()
        {
            Users = new List<User>
                         {
                             new User
                                 {
                                     FirstName = "Bootsy",
                                     LastName = "Collins",
                                     TelephoneNumber = "07111111111",
                                     Id = Guid.NewGuid()
                                 },
                             new User
                                 {
                                     FirstName = "Fred",
                                     LastName = "Wesley",
                                     TelephoneNumber = "07222222222",
                                     Id = Guid.NewGuid()
                                 },
                             new User
                                 {
                                     FirstName = "Maceo",
                                     LastName = "Parker",
                                     TelephoneNumber = "07333333333",
                                     Id = Guid.NewGuid()
                                 },
                         };
        }

    #region Implementation of IUserRepository

        public bool Add(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                Users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(User user)
        {
            var index = Users.FindIndex(x => x.Id == user.Id);
            if(index < 0) return false;

            Users[index] = user;
            return true;
        }

        public bool Delete(User user)
        {
            try
            {
                var toRemove = Users.SingleOrDefault(x => x.Id == user.Id);
                return toRemove != null && Users.Remove(toRemove);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            var user = Find(id);
            if (user == null) return false;

            return Delete(user);
        }

        public IList<User> All()
        {
            return Users;
        }

        public User Find(Guid id)
        {
            return Users.SingleOrDefault(x => x.Id == id);
        }

        #endregion
    }
}
