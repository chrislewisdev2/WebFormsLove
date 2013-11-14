namespace WebFormsLove.Core.Presenters
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public class AddUserPresenter : Presenter<IAddUserView>
    {
        private readonly IUserRepository _repository;

        public AddUserPresenter(IAddUserView view, IUserRepository repository) : base(view)
        {
            _repository = repository;
            view.AddingUser += OnAddingUser;
            view.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            View.Model.Result = FormResult.None;
        }


        private void OnAddingUser(object sender, AddEventArgs<User> e)
        {
            var success = _repository.Add(e.Item);

            var msg = success 
                ? FormMessageModel.Success("User added") 
                : FormMessageModel.Error("User add failed");

            Messages.Publish(msg);
        }
    }
}
