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
    public class EditUserPresenterTest
    {
        private IUserRepository _repo;
        private IEditUserView _view;
        private EditUserPresenter _presenter;

        #region init/cleanup
        [TestInitialize]
        public void TestInit()
        {
            _repo = MockRepository.GenerateMock<IUserRepository>();
            _view = MockRepository.GenerateStub<IEditUserView>();
            _presenter = new EditUserPresenter(_view, _repo)
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
        #endregion init/cleanup

        #region Constructor

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ConstructorDoesntTolerateNullRepository()
        {
            new EditUserPresenter(_view, null);
        }

        [TestMethod]
        public void ConstructorHooksUpEventHandlers()
        {
            // Arrange
            _view.Expect(x => x.SelectingUser += Arg<EventHandler<SelectEventArgs>>.Is.Anything);
            _view.Expect(x => x.UpdatingUser += Arg<EventHandler<UpdateEventArgs<User>>>.Is.Anything);

            new EditUserPresenter(_view, _repo);
        }

        #endregion Constructor
        
        #region Select
        [TestMethod]
        public void CanSelectUsers()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid() };

            _repo.Expect(x => x.Find(user.Id)).Return(user);

            // Act
            _view.Raise(x => x.SelectingUser += null, _view, new SelectEventArgs { Id = user.Id });

            // Assert
            Assert.AreEqual(user, _view.Model.User);
        }

        [TestMethod]
        public void ReportsInvalidSelections()
        {
            // Arrange
            _presenter.Messages.Expect(
                x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Error)));

            // Act
            _view.Raise(x => x.SelectingUser += null, _view, new SelectEventArgs { Id = Guid.Empty });

            // Assert
            Assert.IsNull(_view.Model.User);
        }

        #endregion Select

        #region Update
        [TestMethod]
        public void CanUpdateUsers()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid() };

            _repo.Expect(x => x.Update(user)).Return(true);

            _presenter.Messages.Expect(
                x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Success)));

            // Act
            _view.Raise(x => x.UpdatingUser += null, _view, new UpdateEventArgs<User> { Updated = user });
        }

        [TestMethod]
        public void ReportsFailedUpdated()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid() };

            _repo.Expect(x => x.Update(user)).Return(false);

            _presenter.Messages.Expect(
                x => x.Publish(Arg<FormMessageModel>.Matches(msg => msg.Result == FormResult.Error)));

            // Act
            _view.Raise(x => x.UpdatingUser += null, _view, new UpdateEventArgs<User> { Updated = user });

        } 
        #endregion Update

    }
}
