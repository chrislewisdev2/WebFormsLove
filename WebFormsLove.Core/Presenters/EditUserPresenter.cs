namespace WebFormsLove.Core.Presenters
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public class EditUserPresenter : Presenter<IEditUserView>
    {
        private readonly IUserRepository _repository;

        public EditUserPresenter(IEditUserView view, IUserRepository repository) : base(view)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;

            view.UpdatingUser += OnUpdatingUser;
            view.SelectingUser += OnSelectingUser;
        }

        private void OnUpdatingUser(object sender, UpdateEventArgs<User> e)
        {
            var sucess = _repository.Update(e.Updated);

            var msg = sucess 
                ? FormMessageModel.Success("User updated") 
                : FormMessageModel.Error("User update failed");

            Messages.Publish(msg);
        }

        private void OnSelectingUser(object sender, SelectEventArgs e)
        {
            if (e.Id == Guid.Empty)
            {
                Messages.Publish(FormMessageModel.Error("No user selected"));
                return;
            }

            View.Model.User = _repository.Find(e.Id);
        }
    }
}