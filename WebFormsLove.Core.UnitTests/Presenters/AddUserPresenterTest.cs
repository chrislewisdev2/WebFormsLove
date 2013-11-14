namespace WebFormsLove.Core.UnitTests.Presenters
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    [TestClass]
    public class AddUserPresenterTest
    {
        private IUserRepository _repo;
        private IAddUserView _view;
        private AddUserPresenter _presenter;

        [TestInitialize]
        public void TestInit()
        {
            _repo = MockRepository.GenerateMock<IUserRepository>();
            _view = MockRepository.GenerateStub<IAddUserView>();
            _presenter = new AddUserPresenter(_view, _repo)
            {
                Messages = MockRepository.GenerateMock<IMessageCoordinator>()
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repo.VerifyAllExpectations();
            _view.VerifyAllExpectations();
            _presenter.Messages.VerifyAllExpectations();
        }

        [TestMethod]
        public void ConstructorHooksUpEventHandlers()
        {
            // Arrange
            _view.Expect(x => x.AddingUser += Arg<EventHandler<AddEventArgs<User>>>.Is.Anything);

            // Act
            new AddUserPresenter(_view, _repo);
        }

        [TestMethod]
        public void AddsUserToRepository()
        {
            // Arrange
            var user = new User {Id = Guid.NewGuid()};

            // Act
            _repo.Expect(x => x.Add(user)).Return(true);
            _presenter.Messages.Expect(x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Success)));

            _view.Raise(x => x.AddingUser += null, _view, new AddEventArgs<User> {Item = user});
        }

        [TestMethod]
        public void HandlesFailureToAddUser()
        {
            // Arrange
            var user = new User {Id = Guid.NewGuid()};

            _repo.Expect(x => x.Add(user)).Return(false);
            _presenter.Messages.Expect(x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Error)));

            // Act
            _view.Raise(x => x.AddingUser += null, _view, new AddEventArgs<User> {Item = user});
        }


    }
}