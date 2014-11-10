<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="anonimoPrincpal" runat=server>
<div class=paginas>
    <p>
        &nbsp;</p>
    <h2>
        Bienvenido al Sistema de Gestión Académica (SGA)
    </h2>
    <p>
        Para poder acceder, por favor <a href=Login.aspx title="Login">logueate</a>.
    </p>
</div>
</asp:Panel>
<asp:Panel ID="usuarioPrincipal" runat=server Visible=false>
<div class=paginas>
    <p>
        &nbsp;</p>
    <h2>
        Bienvenido al Sistema de Autogestión ACADEMIA
    </h2>
    <p>
        Bievenido <asp:Label ID="usuarioBienvenido" runat=server ForeColor=Red></asp:Label> !!
    </p>
</div>
</asp:Panel>
</asp:Content>
