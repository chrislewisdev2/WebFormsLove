namespace WebFormsLove.Core.Views
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public interface IEditUserView : IView<EditUserViewModel>
    {
        User SelectUser(string id);
        void UpdateUser(User originalUser, User user);

        event EventHandler<UpdateEventArgs<User>> UpdatingUser;
        event EventHandler<SelectEventArgs> SelectingUser;
    }
}