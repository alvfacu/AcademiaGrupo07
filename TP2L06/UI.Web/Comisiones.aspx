<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<div class=paginas>
<asp:Panel ID="adminPanel" runat=server>
<asp:Panel ID="gridPanel" runat="server">
    <br />
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor=Orange
        SelectedRowStyle-ForeColor=Black HorizontalAlign=Center
        DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
        Width="379px">
        <Columns>
            <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="IDPlan" DataField="IDPlan" />
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
    <asp:Label ID="anioLabel" runat="server" Text="Año Especialidad: "></asp:Label>
    <asp:TextBox ID="anioTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="anioTextBox"  
       ErrorMessage='Especifique año' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="anioTextBox"
       ErroMessage='El año debe ser un número entero' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:CompareValidator>
    <br />
    <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="DescripcionRequerida" runat="server" ControlToValidate="descripcionTextBox"  
       ErrorMessage='Se requerie alguna descripción' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="planLabel" runat=server Text="Plan: "></asp:Label>
    <asp:DropDownList ID="planesList" runat=server></asp:DropDownList>
    <br />
    <br />
</div>
</asp:Panel>

<asp:Panel ID="errorPanel" runat=server Visible=false>
<asp:Label ID="mensajeError" runat=server ForeColor=Red></asp:Label>
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
</asp:Panel>
</div>

</asp:Content>
