
namespace WebFormsLove.Controls
{
    using System;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Helpers;

    public partial class AddUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnUserSubmit(object sender, EventArgs e)
        {
            var user = new User
                           {
                               FirstName = firstName.Text,
                               LastName = lastName.Text,
                               TelephoneNumber = telephoneNumber.Text
                           };

            // TODO: validation

            var repo = new InMemoryUserRepository();
            var success = repo.Add(user);

            if(success)
            {
                message.InnerText = "User added successfully";
                message.AddClass("msg--success");
            }
            else
            {
                message.InnerText = "Something went wrong";
                message.AddClass("msg--error");
            }
        }
    }
}