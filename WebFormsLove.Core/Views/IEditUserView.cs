namespace WebFormsLove.Core.Views
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public interface IEditUserView : IView<EditUserViewModel>
    {
        event EventHandler<UpdateEventArgs<User>> UpdatingUser;
        event EventHandler<SelectEventArgs> SelectingUser;
    }
}