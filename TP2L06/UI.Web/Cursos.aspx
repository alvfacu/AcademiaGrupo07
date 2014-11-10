<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

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
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" />
            <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
            <asp:BoundField HeaderText="ID Comision" DataField="IDComision" />
            <asp:BoundField HeaderText="ID Materia" DataField="IDMateria" />
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
    <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="DescripcionRequerida" runat="server" ControlToValidate="descripcionTextBox"  
       ErrorMessage='Ingrese descripción' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="anioLabel" runat="server" Text="Año Calendario: "></asp:Label>
    <asp:TextBox ID="anioTextBox" runat=server Width="88px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="AnioRequerido" runat="server" ControlToValidate="anioTextBox"  
       ErrorMessage='Ingresa Año Calendario' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="AnioCorrecto" controltovalidate="anioTextBox" validationexpression="^[0-9]+$" 
       Errormessage="Ingrese un año correcto (número)" EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red />
    <br />
    <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
    <asp:TextBox ID="cupoTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="CupoRequerido" runat="server" ControlToValidate="descripcionTextBox"  
       ErrorMessage='Ingrese cupo' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" id="CupoCorrecto" controltovalidate="cupoTextBox" validationexpression="^[0-9]+$" 
       Errormessage="Ingrese cantidad correcta" EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red/>
    <br />
    <asp:Label ID="comisionLabel" runat="server" Text="Comision: "></asp:Label>
    <asp:DropDownList ID="comisionesList" runat=server></asp:DropDownList>    
    <br />
    <asp:Label ID="materiaLabel" runat="server" Text="Materia: "></asp:Label>
    <asp:DropDownList ID="materiasList" runat=server></asp:DropDownList>    
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
</asp:Panel>
</div>
</asp:Content>

