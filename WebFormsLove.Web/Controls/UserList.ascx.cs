namespace WebFormsLove.Controls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebFormsLove.Core.Models;
    using WebFormsLove.Core.Repositories;
    using WebFormsLove.Helpers;

    public partial class UserList : UserControl
    {
        private readonly IUserRepository _repo = new InMemoryUserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            BindData();

        }

        protected void OnUserBound(object sender, ListViewItemEventArgs e)
        {
            var lvi = e.Item;
            if (lvi.ItemType != ListViewItemType.DataItem) return;

            var user = lvi.DataItem as User;
            if (user == null) return;

            lvi.FindBind<Literal>("firstName", x => x.Text = user.FirstName);
            lvi.FindBind<Literal>("lastName", x => x.Text = user.LastName);
            lvi.FindBind<Literal>("TelephoneNumber", x => x.Text = user.TelephoneNumber);
        }

        protected void DeleteUser(string rawId)
        {
            var id = Guid.Parse(rawId);
            var success = _repo.Delete(id);

            if (success)
            {
                message.InnerText = "User deleted";
                message.AddClass("msg--success");
            }
            else
            {
                message.InnerText = "Something went wrong :(";
                message.AddClass("msg--error");
            }

            BindData();
        }

        protected void HandleCommand(object sender, ListViewCommandEventArgs e)
        {
            DeleteUser((string) e.CommandArgument);
        }

        private void BindData()
        {
            userList.DataSource = _repo.All();
            userList.DataBind();
        }
    }
}