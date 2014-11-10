<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<div class=paginas>
<asp:Panel ID="adminPanel" runat=server>
<asp:Panel ID="gridPanel" runat="server">
<br />
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" HorizontalAlign=Center
        SelectedRowStyle-BackColor=Orange
        SelectedRowStyle-ForeColor=Black
        DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="EMail" DataField="EMail" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:CheckBoxField HeaderText="Habilitado" DataField="Habilitado" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Panel>

<br />

<asp:Panel ID="gridActionPanel" runat=server>
    <asp:LinkButton ID="editarLinkButton" runat=server CausesValidation=false 
        onclick="editarLinkButton_Click">Editar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="eliminarLinkButton" runat=server CausesValidation="False"
        onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    &nbsp;&nbsp;
    <asp:LinkButton ID="nuevoLinkButton" runat=server CausesValidation=false 
        onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
</asp:Panel>
<br />
<asp:Panel ID="usuarioPanel" runat=server Visible=false>
<asp:Panel ID="formPanel" runat="server">
<div class=formulario>
<br />
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
    <asp:CheckBox ID="habilitadoCheckBox" runat="server" Text="Habilitado" />
    <br />
    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="nombreUsuarioTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="UsuarioRequerido" runat="server" ControlToValidate="nombreUsuarioTextBox"  
       ErrorMessage='El nombre de usuario no puede estar vacío' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="claveTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="ClaveRequerido" runat="server" ControlToValidate="claveTextBox"  
       ErrorMessage='La clave no puede estar vacía' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="repetirClaveTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="RepetirClaveRequerido" runat="server" ControlToValidate="repetirClaveTextBox"  
       ErrorMessage='Debe confirmar la clave' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompararClave" runat=server  ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" Text="*"
       ErrorMessage='Las claves no coinciden' ForeColor=Red></asp:CompareValidator>
       <br />
       <br />
</div>
</asp:Panel>

<asp:Panel ID="errorPanel" runat=server Visible=false>
<asp:Label ID="mensajeError" runat=server ForeColor=Red></asp:Label>
</asp:Panel>

<asp:ValidationSummary ID="ResumenValidaciones" ForeColor=Red runat="server" HeaderText="Los siguientes errores ocurrieron:" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" /> 

<asp:Panel ID="formActionsPanel" runat=server>
    <asp:LinkButton ID="aceptarLinkButton" runat=server
        onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="cancelarLinkButton" runat=server CausesValidation="False"
        onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
</asp:Panel>
<br />
<br />
</asp:Panel>
</div>
</asp:Content>
