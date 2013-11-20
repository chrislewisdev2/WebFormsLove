namespace WebFormsLove.Controls
{
    using System;
    using System.Web.UI.WebControls;
    using WebFormsLove.Core.Presenters;
    using WebFormsLove.Core.Views;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;
    using WebFormsMvp.Web;

    [PresenterBinding(typeof(FormMessagePresenter))]
    public partial class FormMessage : MvpUserControl<FormMessageModel>, IFormMessageView
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            View view;
            switch (Model.Result)
            {
                case FormResult.Success:
                    view = successView;
                    break;
                case FormResult.Error:
                    view = errorView;
                    break;
                default: //FormResult.None
                    view = emptyView;
                    break;
            }

            mvFormMessage.SetActiveView(view);
        }
    }
}