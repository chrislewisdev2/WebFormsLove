<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebFormsLove._Default" %>
<%@ Register TagPrefix="uc" TagName="UserList" Src="~/Controls/UserList.ascx" %>
<%@ Register TagPrefix="uc" TagName="FormMessage" Src="~/Controls/FormMessage.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Users list</h2>
    <uc:FormMessage runat="server" ID="formMessage" />
    <uc:UserList runat="server" ID="userList" />
</asp:Content>
