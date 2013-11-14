<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserList.ascx.cs" Inherits="WebFormsLove.Controls.UserList" %>

<asp:ListView runat="server" ID="userList" DataSourceID="userSource" DataKeyNames="Id" >
    <LayoutTemplate>
        <table>
            <thead>
                <tr>
                    <th>First name</th>
                    <th>Last name</th>
                    <th>Telephone no.</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>                
            </tbody>
        </table>
    </LayoutTemplate>

    <ItemTemplate>
        <tr>
            <td><%# Eval("firstName") %></td>
            <td><%# Eval("lastName") %></td>
            <td><%# Eval("telePhoneNumber") %></td>
            <td><asp:HyperLink runat="server" NavigateUrl='<%# "/EditUser.aspx?id=" + Eval("Id") %>' Text="Edit" /></td>
            <td><asp:Button ID="deleteBtn" runat="server" CommandName="Delete" Text="Delete"/></td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p>No users added yet&hellip; Add a <a href="/AddUser.aspx">new user</a></p>
    </EmptyDataTemplate>
    
</asp:ListView>

<mvp:PageDataSource runat="server" ID="userSource"
    DeleteMethod="DeleteUser"
    SelectMethod="SelectUsers"/>