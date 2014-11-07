<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormMessage.ascx.cs" Inherits="WebFormsLove.Controls.FormMessage" %>

<asp:MultiView runat="server" ID="mvFormMessage">
    <asp:View runat="server" ID="successView" >
        <div class="msg msg--success">
            <p><%= Model.Message %></p>
        </div>
    </asp:View>
    <asp:View runat="server" ID="errorView">
        <div class="msg msg--error">
            <p><%= Model.Message %></p>
        </div>
    </asp:View>
    <asp:View runat="server" ID="emptyView"/>
</asp:MultiView>