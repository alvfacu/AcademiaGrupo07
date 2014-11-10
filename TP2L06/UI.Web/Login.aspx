<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class=paginas>
<asp:Panel ID="headerLogin" runat="server">
    <p>
        &nbsp;</p>
    <h2>
        Ingresar
    </h2>
    <p>
        <em><strong>Por favor ingresa tu nombre de usuario y tu clave. </strong></em>
    </p>
</asp:Panel>
<asp:ValidationSummary ID="ResumenValidaciones" ForeColor=Red runat="server" HeaderText="Los siguientes errores ocurrieron:" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" /> 
<div class=error>
<asp:Label ID="Label1" runat="server"></asp:Label>
</div>
<asp:Panel ID="panelLogin" runat=server HorizontalAlign="Center">
    <div class=login>
        <p>
            &nbsp;&nbsp;<br /> &nbsp;<asp:Label ID="usuarioLabel" runat="server" 
                Text="Nombre de Usuario: "></asp:Label>
            <asp:TextBox ID="usuarioTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UsuarioRequerido" runat="server" 
                ControlToValidate="usuarioTextBox" EnableClientScript="true" 
                ErrorMessage="Ingrese un nombre de usuario" ForeColor="Red" 
                SetFocusOnError="true" Text="*"></asp:RequiredFieldValidator>
            &nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ClaveRequerida" runat="server" 
                ControlToValidate="claveTextBox" EnableClientScript="true" 
                ErrorMessage="Ingrese una clave" ForeColor="Red" SetFocusOnError="true" 
                Text="*"></asp:RequiredFieldValidator>
            <br />
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ingresarButton" runat="server" onclick="ingresarButton_Click" 
                Text="Ingresar" />
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
        </p>
    </div>
</asp:Panel>
</div>
<br />
<br />
<br />
</asp:Content>
