namespace WebFormsLove.Controls
{
    using System;
    using System.Collections.Generic;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;
    using WebFormsMvp.Web;

    [PresenterBinding(typeof (UserListPresenter))]
    public partial class UserList : MvpUserControl<UserListViewModel>, IUserListView
    {
        public IList<User> SelectUsers()
        {
            return Model.Users;
        }

        public void DeleteUser(Guid id)
        {
            if (DeletingUser != null)
                DeletingUser(this, new SelectEventArgs {Id = id});
        }

        #region Implementation of IUserListView

        public event EventHandler<SelectEventArgs> DeletingUser;

        #endregion
    }
}