using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebFormsLove.Core.UnitTests.Presenters
{
    using Rhino.Mocks;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.EventArgs;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    [TestClass]
    public class UserListPresenterTest
    {
        private IUserListView _view;
        private IUserRepository _repository;
        private UserListPresenter _presenter;
        private UserListViewModel _viewModel;

        #region Test init/cleanup

        [TestInitialize]
        public void TestInit()
        {
            _viewModel = new UserListViewModel();

            _view = MockRepository.GenerateMock<IUserListView>();
            _view.Stub(x => x.Model).Return(_viewModel);

            _repository = MockRepository.GenerateMock<IUserRepository>();

            _presenter = new UserListPresenter(_view, _repository)
            {
                Messages = MockRepository.GenerateMock<IMessageCoordinator>()
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _view.VerifyAllExpectations();
            _repository.VerifyAllExpectations();
        }

        #endregion Test init/cleanup

        #region Constructor

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ConstructorDoesntTolerateNullRepository()
        {
            new UserListPresenter(_view, null);
        }

        [TestMethod]
        public void ConstructorHooksUpEventHandlers()
        {
            // Arrange
            _view.Expect(x => x.Load += Arg<EventHandler>.Is.Anything);
            _view.Expect(x => x.DeletingUser += Arg<EventHandler<SelectEventArgs>>.Is.Anything);

            // Act
            new UserListPresenter(_view, _repository);
        }

        #endregion Constructor

        #region Load

        [TestMethod]
        public void SelectsAllUserOnLoad()
        {
            // Arrange
            var users = new List<User>();
            _repository.Expect(x => x.All()).Return(users);

            // Act
            _view.Raise(x => x.Load += null, _view, new EventArgs());

            // Assert
            Assert.AreEqual(users, _view.Model.Users);
        }

        #endregion Load

        #region Delete

        [TestMethod]
        public void CanDeleteUsers()
        {
            // Arrange
            var userId = Guid.NewGuid();
            _repository.Expect(x => x.Delete(userId)).Return(true);
            _presenter.Messages.Expect(
                x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Success)));

            // Act
            _view.Raise(x => x.DeletingUser += null, _view, new SelectEventArgs{Id = userId});
        }

        [TestMethod]
        public void ReportsFailedDeletion()
        {
            // Arrange
            var userId = Guid.NewGuid();
            _repository.Expect(x => x.Delete(userId)).Return(false);
            _presenter.Messages.Expect(
                x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Error)));

            // Act
            _view.Raise(x => x.DeletingUser += null, _view, new SelectEventArgs{Id = userId});
        }

        #endregion Delete
    }
}
