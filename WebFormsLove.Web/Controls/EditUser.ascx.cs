namespace WebFormsLove.Controls
{
    using System;
    using System.Web.UI;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Helpers;

    public partial class EditUser : UserControl
    {
        private readonly IUserRepository _repo = new InMemoryUserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string id = Request.QueryString["id"];
            if (string.IsNullOrWhiteSpace(id))
            {
                message.InnerText = "No user selected";
                message.AddClass("msg--error");
                return;
            }

            Guid guidId;
            if (!Guid.TryParse(id, out guidId))
            {
                message.InnerText = "No user selected";
                message.AddClass("msg--error");
            }

            var user = _repo.Find(guidId);

            firstName.Text = user.FirstName;
            lastName.Text = user.LastName;
            telephoneNumber.Text = user.TelephoneNumber;
            userId.Value = user.Id.ToString();
        }

        protected void OnUserEdit(object sender, EventArgs e)
        {
            var updated = new User
                              {
                                  FirstName = firstName.Text,
                                  LastName = lastName.Text,
                                  TelephoneNumber = telephoneNumber.Text,
                                  Id = Guid.Parse(userId.Value)
                              };

            var success = _repo.Update(updated);
            if(success)
            {
                message.InnerText = "User updated";
                message.AddClass("msg--success");
            }
            else
            {
                message.InnerText = "Update failed";
                message.AddClass("msg--error");
            }
        }
    }
}