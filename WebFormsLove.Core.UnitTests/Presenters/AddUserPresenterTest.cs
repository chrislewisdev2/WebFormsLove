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

    [TestClass]
    public class AddUserPresenterTest
    {
        private IUserRepository _repo;
        private IAddUserView _view;

        [TestInitialize]
        public void TestInit()
        {
            _repo = MockRepository.GenerateMock<IUserRepository>();
            _view = MockRepository.GenerateStub<IAddUserView>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repo.VerifyAllExpectations();
            _view.VerifyAllExpectations();
        }

        [TestMethod]
        public void ConstructorHooksUpEventHandlers()
        {
            // Arrange
            _view.Expect(x => x.Load += Arg<EventHandler>.Is.Anything);
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

            _view.Raise(x => x.AddingUser += null, _view, new AddEventArgs<User> {Item = user});
        }
    }
}