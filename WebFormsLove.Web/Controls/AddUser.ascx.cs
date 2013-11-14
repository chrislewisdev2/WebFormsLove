namespace WebFormsLove.Controls
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;
    using WebFormsMvp.Web;

    [PresenterBinding(typeof (AddUserPresenter))]
    public partial class AddUser : MvpUserControl<AddUserViewModel>, IAddUserView
    {
        public AddUser()
        {
            AutoDataBind = false;
        }

        public void CreateUser(User user)
        {
            if (AddingUser != null)
            {
                AddingUser(this, new AddEventArgs<User> {Item = user});
            }
        }

        #region Implementation of IAddUserView

        public event EventHandler<AddEventArgs<User>> AddingUser;

        #endregion
    }
}