using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebFormsLove.Core.UnitTests.Presenters
{
    using Rhino.Mocks;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    [TestClass]
    public class FormMessagePresenterTest
    {
        private IFormMessageView _view;
        private FormMessagePresenter _presenter;

        #region init/cleanup

        [TestInitialize]
        public void TestInit()
        {
            _view = MockRepository.GenerateStub<IFormMessageView>();
            _presenter = new FormMessagePresenter(_view)
            {
                Messages = MockRepository.GenerateMock<IMessageCoordinator>()
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _presenter.Messages.VerifyAllExpectations();
            _view.VerifyAllExpectations();
        }

        #endregion init/cleanup

        [TestMethod]
        public void ConstructorHooksUpEventHandlers()
        {
            // Arrange
            var view = MockRepository.GenerateMock<IFormMessageView>();
            view.Expect(x => x.Load += Arg<EventHandler>.Is.Anything);

            // Act
            new FormMessagePresenter(view);

            // Assert
            view.VerifyAllExpectations();
        }

        [TestMethod]
        public void LoadBootstrapsPage()
        {
            // Arrange
            _presenter.Messages
                .Expect(x => x.Subscribe(Arg<Action<FormMessageModel>>.Is.Anything))
                .Repeat.Once();

            // Act
            _view.Raise(x => x.Load += null, _view, new EventArgs());
        }
    }
}
