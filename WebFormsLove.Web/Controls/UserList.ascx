<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserList.ascx.cs" Inherits="WebFormsLove.Controls.UserList" %>

<p runat="server" id="message" class="msg"></p>

<asp:ListView runat="server" ID="userList" OnItemDataBound="OnUserBound" OnItemCommand="HandleCommand">
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
            <td><asp:Button ID="deleteBtn" runat="server" CommandArgument='<%# Eval("Id") %>' Text="Delete"/></td>
        </tr>
    </ItemTemplate>
    
</asp:ListView>