namespace WebFormsLove.Core.Views
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public interface IAddUserView : IView<AddUserViewModel>
    {
        void CreateUser(User user);

        event EventHandler<AddEventArgs<User>> AddingUser;
    }
}