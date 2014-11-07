namespace WebFormsLove.Core.Views.EventArgs
{
    using System;

    public class AddEventArgs<TModel> : EventArgs where TModel : class, new()
    {
        public TModel Item { get; set; }
    }
}