namespace WebFormsLove.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using WebFormsLove.Core.Models;

    public interface IUserRepository
    {
        bool Add(User user);
        bool Update(User user);
        
        bool Delete(User user);
        bool Delete(Guid id);

        IList<User> All();
        User Find(Guid id);
    }
}