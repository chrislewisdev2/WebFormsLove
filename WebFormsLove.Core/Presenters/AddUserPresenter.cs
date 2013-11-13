namespace WebFormsLove.Core.Presenters
{
    using System;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
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


        private void OnAddingUser(object sender, AddUserEventArgs e)
        {
            var success = _repository.Add(e.User);

            if(success)
            {
                View.Model.Result = FormResult.Success;
                View.Model.Message = "User added";
            }
            else
            {
                View.Model.Result = FormResult.Error;
                View.Model.Message = "Failed to add user";
            }
        }
    }
}
