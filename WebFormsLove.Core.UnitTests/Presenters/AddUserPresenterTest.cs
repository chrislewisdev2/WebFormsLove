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

    [TestClass]
    public class AddUserPresenterTest
    {
        private IUserRepository _repo;
        private AddUserPresenter _presenter;
        private IAddUserView _view;

        [TestInitialize]
        public void TestInit()
        {
            //get a base identity set up
            _repo = MockRepository.GenerateMock<IUserRepository>();
            _view = MockRepository.GenerateStub<IAddUserView>();
            _presenter = new AddUserPresenter(_view, _repo);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repo.VerifyAllExpectations();
        }

        [TestMethod]
        public void ConstructorHooksUpEventHandlers()
        {
            // Arrange
            _view.Expect(x => x.Load += Arg<EventHandler>.Is.Anything);

            // Act
            new AddUserPresenter(_view, _repo);

            // Assert
            _view.VerifyAllExpectations();
        }

        [TestMethod]
        public void AddsUserToRepository()
        {
            var user = new User {Id = Guid.NewGuid()};

            _repo.Expect(x => x.Add(user)).Return(true);

            _view.Raise(x => x.AddingUser += null, _view, new AddUserEventArgs{User = user});
        }
    }
}
