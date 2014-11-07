namespace WebFormsLove.Core.Presenters
{
    using System;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    /// <summary>
    /// Handles messages published by form presenters, to decouple 
    /// form handling from reporting back to user
    /// </summary>
    public class FormMessagePresenter : Presenter<IFormMessageView>
    {
        public FormMessagePresenter(IFormMessageView view) : base(view)
        {
            view.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Messages.Subscribe<FormMessageModel>(msg => { View.Model = msg; });
        }
    }
}