<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulosUsuarios.aspx.cs" Inherits="UI.Web.ModulosUsuarios" %>

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
            <asp:BoundField HeaderText="ID Modulo" DataField="IDModulo" />
            <asp:BoundField HeaderText="ID Usuario" DataField="IDUsuario" />
            <asp:CheckBoxField HeaderText="Permite Alta" DataField="PermiteAlta" />
            <asp:CheckBoxField HeaderText="Permite Baja" DataField="PermiteBaja" />
            <asp:CheckBoxField HeaderText="Permite Modificación" DataField="PermiteModificacion" />
            <asp:CheckBoxField HeaderText="Permite Consulta" DataField="PermiteConsulta" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True"/>
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
    <asp:Label ID="moduloLabel" runat="server" Text="Modulo: "></asp:Label>
    <asp:DropDownList ID="modulosList" runat=server></asp:DropDownList>    
    <br />
    <asp:Label ID="usuarioLabel" runat="server" Text="Usuario: "></asp:Label>
    <asp:DropDownList ID="usuariosList" runat=server></asp:DropDownList>    
    <br />
    <asp:Table ID="Table1" runat="server" Width="360px" HorizontalAlign=Center>
    <asp:TableRow>
     <asp:TableCell><asp:CheckBox ID="altaCheck" runat=server Text="Permite Alta " /></asp:TableCell>
     <asp:TableCell><asp:CheckBox ID="bajaCheck" runat=server Text="Permite Baja " /></asp:TableCell>
   </asp:TableRow>
   <asp:TableRow>
     <asp:TableCell><asp:CheckBox ID="modificacionCheck" runat=server Text="Permite Modificacion " /></asp:TableCell>
     <asp:TableCell><asp:CheckBox ID="consultaCheck" runat=server Text="Permite Consulta " /></asp:TableCell>
   </asp:TableRow>
    </asp:Table>
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
