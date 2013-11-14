<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebFormsLove.EditUser" %>
<%@ Register tagPrefix="uc" tagName="EditUser" src="Controls/EditUser.ascx" %>
<%@ Register TagPrefix="uc" TagName="FormMessage" Src="~/Controls/FormMessage.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit a user</h2>
    <uc:FormMessage runat="server" ID="formMessage" />
    <uc:EditUser runat="server" />
</asp:Content>
