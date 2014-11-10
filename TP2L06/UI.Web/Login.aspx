<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class=link>
<asp:Panel ID="headerLogin" runat="server">
    <h2>
        Ingresar
    </h2>
    <p>
        Por favor ingresa tu nombre de usuario y tu clave.
    </p>
</asp:Panel>
<asp:ValidationSummary ID="ResumenValidaciones" ForeColor=Red runat="server" HeaderText="Los siguientes errores ocurrieron:" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" /> 

<asp:Panel ID="panelLogin" runat=server HorizontalAlign="Center">
    <div class=login>
    <br />
    &nbsp;&nbsp;
        <asp:Label ID="usuarioLabel" runat="server" Text="Nombre de Usuario: "></asp:Label>
        <asp:TextBox ID="usuarioTextBox" runat=server></asp:TextBox>
        <asp:RequiredFieldValidator ID="UsuarioRequerido" runat="server" ControlToValidate="usuarioTextBox"  
            ErrorMessage='Ingrese un nombre de usuario' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
        &nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode=Password runat=server></asp:TextBox>
        <asp:RequiredFieldValidator ID="ClaveRequerida" runat="server" ControlToValidate="claveTextBox"  
            ErrorMessage='Ingrese una clave' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ingresarButton" runat=server Text="Ingresar" 
            onclick="ingresarButton_Click"/> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" ForeColor=Red></asp:Label>
        <br />
    </div>
</asp:Panel>
</div>
<br />
<br />
<br />
</asp:Content>
