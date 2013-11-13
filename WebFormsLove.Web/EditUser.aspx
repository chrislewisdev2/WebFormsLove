<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebFormsLove.EditUser" %>
<%@ Register tagPrefix="uc" tagName="editUser" src="Controls/EditUser.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc:editUser runat="server" />
</asp:Content>
