<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditUser.ascx.cs" Inherits="WebFormsLove.Controls.EditUser" %>

<fieldset>
    <legend>Users details</legend>

    <asp:FormView ID="addUserFormView" runat="server" DefaultMode="Edit" DataSourceID="userSource" RenderOuterTable="False">
        <EditItemTemplate>
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
            <asp:HiddenField runat="server" ID="userId" Value='<%# Bind("Id") %>'/>
            <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Update user"/>
        </EditItemTemplate>
    </asp:FormView>
    
</fieldset>

<mvp:PageDataSource runat="server" ID="userSource"
    DataObjectTypeName="WebFormsLove.Core.Models.User"
    ConflictDetection="CompareAllValues"
    OldValuesParameterFormatString="original{0}"
    UpdateMethod="UpdateUser"
    SelectMethod="SelectUser">
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="id" Name="id" />
    </SelectParameters>
</mvp:PageDataSource>