namespace WebFormsLove.Core.Views.EventArgs
{
    using System;

    public class UpdateEventArgs<TModel> : EventArgs where TModel : class, new()
    {
        public TModel Original { get; set; }
        public TModel Updated { get; set; }
    }
}