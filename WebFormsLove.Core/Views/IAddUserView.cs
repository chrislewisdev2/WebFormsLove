namespace WebFormsLove.Core.Views
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsMvp;

    public interface IAddUserView : IView
    {
        void CreateUser(User user);

        event EventHandler<AddEventArgs<User>> AddingUser;
    }
}