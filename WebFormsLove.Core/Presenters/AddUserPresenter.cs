namespace WebFormsLove.Core.Presenters
{
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    /// <summary>
    /// Presenter for handling addition of users
    /// </summary>
    public class AddUserPresenter : Presenter<IAddUserView>
    {
        private readonly IUserRepository _repository;

        public AddUserPresenter(IAddUserView view, IUserRepository repository) : base(view)
        {
            _repository = repository;
            view.AddingUser += OnAddingUser;
        }


        /// <summary>
        /// Called when the user submits the form on the view
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="WebFormsLove.Core.Views.EventArgs.AddEventArgs&lt;WebFormsLove.Core.Models.User&gt;"/> instance containing the event data.</param>
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
