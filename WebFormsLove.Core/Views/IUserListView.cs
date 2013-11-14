namespace WebFormsLove.Core.Views
{
    using System;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public interface IUserListView : IView<UserListViewModel>
    {
        event EventHandler<SelectEventArgs> DeletingUser;
    }
}