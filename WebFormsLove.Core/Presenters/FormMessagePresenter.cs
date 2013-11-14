namespace WebFormsLove.Core.Presenters
{
    using System;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

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