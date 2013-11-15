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

    [PresenterBinding(typeof(EditUserPresenter))]
    public partial class EditUser : MvpUserControl<EditUserViewModel>, IEditUserView
    {
        public EditUser()
        {
            //NOTE: this stops "double data-bind" problem. 
            //See http://codecharm.com/Home/tabid/107/EntryId/56/WebFormsMvp-and-the-AutoDataBind-property.aspx
            AutoDataBind = false;
        }

        #region Implementation of IEditUserView

        public User SelectUser(string id)
        {
            if (SelectingUser != null)
            {
                Guid userId;
                Guid.TryParse(id, out userId);
                SelectingUser(this, new SelectEventArgs { Id = userId });
            }

            return Model.User;
        }

        public void UpdateUser(User originalUser, User user)
        {
            if (UpdatingUser != null)
            {
                UpdatingUser(this, new UpdateEventArgs<User> { Original = originalUser, Updated = user });
            }
        }

        public event EventHandler<UpdateEventArgs<User>> UpdatingUser;
        public event EventHandler<SelectEventArgs> SelectingUser;

        #endregion
    }
}