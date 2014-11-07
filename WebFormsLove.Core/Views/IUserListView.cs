namespace WebFormsLove.Core.Views
{
    using System;
    using System.Collections.Generic;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public interface IUserListView : IView<UserListViewModel>
    {
        IList<User> SelectUsers();
        void DeleteUser(Guid id);

        event EventHandler<SelectEventArgs> DeletingUser;
    }
}