<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="WebFormsLove.AddUser" %>
<%@ Register tagPrefix="uc" tagName="addUser" src="Controls/AddUser.ascx" %>
<%@ Register tagPrefix="uc" tagName="formMessage" src="Controls/FormMessage.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add a user</h2>
    <uc:formMessage runat="server" ID="formMessage"/>
    <uc:addUser runat="server" ID="addUser" />
</asp:Content>
