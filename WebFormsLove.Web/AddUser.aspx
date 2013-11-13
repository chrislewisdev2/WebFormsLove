<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="WebFormsLove.AddUser" %>
<%@ Register tagPrefix="uc" tagName="addUser" src="Controls/AddUser.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:addUser runat="server" ID="addUser" />
</asp:Content>
