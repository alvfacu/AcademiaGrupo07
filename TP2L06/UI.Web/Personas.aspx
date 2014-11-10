<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

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
            <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
            <asp:BoundField HeaderText="ID Plan" DataField="IDPlan" />
            <asp:BoundField HeaderText="Tipo de Persona" DataField="TipoPersona" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
            <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="EMail" DataField="EMail" />
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
    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="nombreTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="NombreRequerido" runat="server" ControlToValidate="nombreTextBox"  
       ErrorMessage='El nombre no puede estar vacío' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ApellidoRequerido" runat="server" 
        ControlToValidate="apellidoTextBox" EnableClientScript="true" 
        ErrorMessage="El apellido no puede estar vacío" ForeColor="Red" 
        SetFocusOnError="true" Text="*"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
    <asp:TextBox ID="legajoTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="LegajoRequerido" runat="server" ControlToValidate="legajoTextBox"  
       ErrorMessage='El legajo no puede estar vacío' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="planLabel" runat=server Text="Plan: "></asp:Label>
    <asp:DropDownList ID="planesList" runat=server></asp:DropDownList>
    <br />
    <asp:Label ID="tiposLabel" runat=server Text="Tipo de Persona: "></asp:Label>
    <asp:DropDownList ID="tiposList" runat=server ></asp:DropDownList>
    <br />
    <asp:Label ID="fechaLabel" runat=server Text="Fecha de Nacimiento: "></asp:Label>
    &nbsp;<asp:Label ID="diaLabel" runat=server Text="Día: "></asp:Label>
    &nbsp;<asp:DropDownList ID="diasList" runat="server" />
    &nbsp;<asp:Label ID="mesLabel" runat=server Text="Mes: "></asp:Label>
    &nbsp;<asp:DropDownList ID="mesesList" runat="server" onchange = "PopulateDays()" />
    &nbsp;<asp:Label ID="anioLabel" runat=server Text="Año: "></asp:Label>
    &nbsp;<asp:DropDownList ID="aniosList" runat="server" onchange = "PopulateDays()" />
    <br />
    <asp:Label ID="direccionLabel" runat="server" Text="Dirección: "></asp:Label>
    <asp:TextBox ID="direccionTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="DireccionRequerida" runat="server" ControlToValidate="direccionTextBox"  
       ErrorMessage='La dirección no puede estar vacía' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    &nbsp;&nbsp;
    <asp:Label ID="telefonoLabel" runat="server" Text="Telefono: "></asp:Label>
    <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="TelefonoRequerido" runat="server" 
        ControlToValidate="telefonoTextBox" EnableClientScript="true" 
        ErrorMessage="El telefono no puede estar vacío" ForeColor="Red" 
        SetFocusOnError="true" Text="*"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;
    <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="EmailInvalido" runat="server" 
        ControlToValidate="emailTextBox" EnableClientScript="true" 
        ErrorMessage="El email es inválido" ForeColor="Red" SetFocusOnError="true" 
        Text="*" 
        ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?">
    </asp:RegularExpressionValidator>
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
    &nbsp;&nbsp;</asp:Panel>
    <br />
    <br />
</asp:Panel>
</div>
</asp:Content>
