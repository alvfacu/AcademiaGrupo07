<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>

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
            <asp:BoundField HeaderText="ID Alumno" DataField="IDAlumno" />
            <asp:BoundField HeaderText="ID Curso" DataField="IDCurso" />
            <asp:BoundField HeaderText="Condición" DataField="Condicion" />
            <asp:BoundField HeaderText="Nota" DataField="Nota" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Panel>
<i style="color:#FE2E2E">*0 (cero) significa que no tiene la nota cargada.*</i>
<br />
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</asp:Panel>
</asp:Panel>
<br />
<asp:Panel ID="usuarioPanel" runat=server Visible=false>
<asp:Panel ID="formPanel" runat="server">
<div class=formulario>
<br />
    <asp:Label ID="apeNomLabel" runat="server" Text="Nombre y Apellido del Alumno: "></asp:Label>
    <asp:DropDownList ID="alumnosList" runat=server></asp:DropDownList>
    <br />
    <asp:Label ID="cursoLabel" runat="server" Text="Curso: "></asp:Label>
    <asp:DropDownList ID="cursoList" runat=server></asp:DropDownList>
    <br />
    <asp:Label ID="condicionLabel" runat="server" Text="Condicion: "></asp:Label>
    <asp:TextBox ID="condicionTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="CondicionRequerida" runat="server" ControlToValidate="condicionTextBox"  
       ErrorMessage='La condición no puede estar vacía' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
    <asp:TextBox ID="notaTextBox" runat=server></asp:TextBox>
    <asp:RequiredFieldValidator ID="NotaRequerida" runat="server" ControlToValidate="notaTextBox"  
       ErrorMessage='La nota no puede estar vacía (ingrese 0 en caso de no tener nota).' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator runat="server" ValidationExpression="\d+" ControlToValidate="notaTextBox" 
        ErroMessage='La nota debe ser un número entero' EnableClientScript="true" SetFocusOnError="true" Text="*" ForeColor=Red></asp:RegularExpressionValidator>
    <br />
<br />
</div>
</asp:Panel>

<asp:Panel ID="noCupoPanel" runat=server Visible=false>
<asp:Label ID="noCupoLabel" runat="server" ForeColor=Red></asp:Label>
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
