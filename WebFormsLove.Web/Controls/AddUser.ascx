<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddUser.ascx.cs" Inherits="WebFormsLove.Controls.AddUser" ClientIDMode="Static" ViewStateMode="Disabled" %>


<p runat="server" id="message" class="msg"></p>
<fieldset>
    <legend>User details</legend>

    <asp:FormView ID="addUserFormView" runat="server" DefaultMode="Insert" DataSourceID="userSource" RenderOuterTable="False">
        <InsertItemTemplate>
            <div>
                <label for="firstName">First name</label>
                <asp:TextBox runat="server" ID="firstName" Text='<%# Bind("FirstName") %>'/>
            </div>
            <div>
                <label for="lastName">Last name</label>
                <asp:TextBox runat="server" ID="lastName" Text='<%# Bind("LastName") %>' />
            </div>
            <div>
                <label for="telephoneNumber">Telepone</label>
                <asp:TextBox runat="server" ID="telephoneNumber" Text='<%# Bind("TelephoneNumber") %>' />
            </div>
            <asp:Button ID="Button1" runat="server" CommandName="Insert" Text="Add user"/>
        </InsertItemTemplate>
    </asp:FormView>

    
</fieldset>

<mvp:PageDataSource runat="server" ID="userSource"
    DataObjectTypeName="WebFormsLove.Core.Models.User"
    InsertMethod="CreateUser"
    SelectMethod="SelectUser"/>