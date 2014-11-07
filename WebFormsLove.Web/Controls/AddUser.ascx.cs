namespace WebFormsLove.Controls
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsMvp;
    using WebFormsMvp.Web;

    [PresenterBinding(typeof (AddUserPresenter))]
    public partial class AddUser : MvpUserControl, IAddUserView
    {
        public AddUser()
        {
            AutoDataBind = false;
        }

        #region Implementation of IAddUserView

        public void CreateUser(User user)
        {
            if (AddingUser != null)
            {
                AddingUser(this, new AddEventArgs<User> {Item = user});
            }
        }

        public event EventHandler<AddEventArgs<User>> AddingUser;

        #endregion
    }
}