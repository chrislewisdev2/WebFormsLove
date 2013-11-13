<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUser.ascx.cs" Inherits="WebFormsLove.Controls.EditUser" %>

<p runat="server" id="message" class="msg"></p>

<fieldset>
    <legend>User details</legend>
    <div>
        <label for="firstName">First name</label>
        <asp:TextBox runat="server" ID="firstName" />
    </div>
    <div>
        <label for="lastName">Last name</label>
        <asp:TextBox runat="server" ID="lastName" />
    </div>
    <div>
        <label for="telephoneNumber">Telepone</label>
        <asp:TextBox runat="server" ID="telephoneNumber" />
    </div>
    <asp:HiddenField runat="server" ID="userId"/>
    <asp:Button ID="Button1" runat="server" OnClick="OnUserEdit" Text="Edit user"/>
</fieldset>