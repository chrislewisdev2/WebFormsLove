<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="WebFormsLove.AllUsers" %>
<%@ Register TagPrefix="uc" TagName="UserList" Src="~/Controls/UserList.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:UserList runat="server" ID="userList" />
</asp:Content>
