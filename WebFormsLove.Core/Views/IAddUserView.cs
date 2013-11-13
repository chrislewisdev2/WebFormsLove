using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormsLove.Core.Views
{
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Views.Model;
    using WebFormsMvp;

    public interface IAddUserView : IView<AddUserViewModel>
    {
        event EventHandler<AddUserEventArgs> AddingUser;
    }

    public class AddUserEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
