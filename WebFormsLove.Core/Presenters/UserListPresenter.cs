namespace WebFormsLove.Core.Presenters
{
    using System;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public class UserListPresenter : Presenter<IUserListView>
    {
        private readonly IUserRepository _repository;

        public UserListPresenter(IUserListView view, IUserRepository repository) : base(view)
        {
            _repository = repository;

            view.Load += OnLoad;
            view.DeletingUser += OnDeletingUser;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            View.Model.Users = _repository.All();
        }

        private void OnDeletingUser(object sender, SelectEventArgs e)
        {
            var success = _repository.Delete(e.Id);

            var msg = success
                ? FormMessageModel.Success("User deleted")
                : FormMessageModel.Error("User deletion failed");

            Messages.Publish(msg);
        }
    }
}