<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="EMail" DataField="EMail" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Panel>

<br />

<asp:Panel ID="gridActionPanel" runat=server>
    <asp:LinkButton ID="editarLinkButton" runat=server 
        onclick="editarLinkButton_Click">Editar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="eliminarLinkButton" runat=server CausesValidation="False"
        onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="nuevoLinkButton" runat=server 
        onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>

<br />

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="apeNomLabel" runat="server" Text="Nombre y Apellido: "></asp:Label>
    <asp:DropDownList ID="personasList" runat=server></asp:DropDownList>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="EmailRequerido" runat="server" ControlToValidate="emailTextBox"  
       ErrorMessage='El email no puede estar vacío' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="EmailInvalido" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email es inválido" 
       EnableClientScript=true SetFocusOnError="true" Text="*" ForeColor=Red
       ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?">
    </asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
    <br />
    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="nombreUsuarioTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="UsuarioRequerido" runat="server" ControlToValidate="nombreUsuarioTextBox"  
       ErrorMessage='El nombre de usuario no puede estar vacío' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="claveTextBox" TextMode=Password runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="ClaveRequerido" runat="server" ControlToValidate="claveTextBox"  
       ErrorMessage='La clave no puede estar vacía' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="repetirClaveTextBox" TextMode=Password runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="RepetirClaveRequerido" runat="server" ControlToValidate="repetirClaveTextBox"  
       ErrorMessage='Debe confirmar la clave' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompararClave" runat=server  ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" Text="*"
       ErrorMessage='Las claves no coinciden' ForeColor=Red></asp:CompareValidator>
</asp:Panel>

<asp:Panel ID="formActionsPanel" runat=server>
    <asp:LinkButton ID="aceptarLinkButton" runat=server 
        onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="cancelarLinkButton" runat=server CausesValidation="False"
        onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
</asp:Panel>
<br />
<br />
<asp:ValidationSummary ID="ResumenValidaciones" ForeColor=Red runat="server" HeaderText="Los siguientes errores ocurrieron:" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" /> 

</asp:Content>
