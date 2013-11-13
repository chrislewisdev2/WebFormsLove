namespace WebFormsLove.Controls
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.Model;
    using WebFormsLove.Helpers;
    using WebFormsMvp;
    using WebFormsMvp.Web;

    [PresenterBinding(typeof (AddUserPresenter))]
    public partial class AddUser : MvpUserControl<AddUserViewModel>, IAddUserView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //TODO: find out why this is needed
        public User SelectUser()
        {
            return new User();
        }


        public void CreateUser(User user)
        {
            if (AddingUser == null) return;

            AddingUser(this, new AddUserEventArgs {User = user});

            //TODO: refactor into own presenter etc
            message.AddClass(Model.Result == FormResult.Success ? "msg--success" : "msg--error");
            message.InnerText = Model.Message;
        }

        #region Implementation of IAddUserView

        public event EventHandler<AddUserEventArgs> AddingUser;

        #endregion
    }
}