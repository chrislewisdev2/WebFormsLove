<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddUser.ascx.cs" Inherits="WebFormsLove.Controls.AddUser" ClientIDMode="Static" ViewStateMode="Disabled" %>


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
    <asp:Button runat="server" OnClick="OnUserSubmit" Text="Add user"/>
</fieldset>