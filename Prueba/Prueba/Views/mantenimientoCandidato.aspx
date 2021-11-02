<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantenimientoCandidato.aspx.cs" Inherits="Prueba.Views.mantenimientoCandidato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <script src="../script/validacionNumeros.js"></script>
    <!-- Estilos -->
    <link href="../css/formulariocandidatos.css" rel="stylesheet" />
    <title>Registro Candidatos</title>
</head>
<body runat="server">
   <form runat="server">
        <header runat="server" class="form-register">
            <center><asp:LinkButton ID="regresar" class="botons" runat="server" OnClick="regresar_Click1">Home</asp:LinkButton></center>
        </header>
        <br />
        <center><asp:Label ID="lblerror" ForeColor="Red" runat="server" Text=""></asp:Label></center>
        <section class="form-register">
        <h4>Formulario Registro</h4>
        <input class="controls" type="tel" name="dpi" id="dpi" onkeypress="return valideKey(event);" placeholder="Ingrese su DPI" runat="server"/>
        <input class="controls" type="text" name="nombres" id="nombres" placeholder="Ingrese sus Nombres" runat="server"/>
        <input class="controls" type="text" name="apellidos" id="apellidos" placeholder="Ingrese sus Apellidos" runat="server"/>
        <input class="controls" type="text" name="direccion" id="direccion" placeholder="Ingrese su Direccion" runat="server"/>
        <input class="controls" type="tel" name="telefono" id="telefono" onkeypress="return valideKey(event);" placeholder="Ingrese su Numero Telefonico" runat="server"/>
        <input class="controls" type="text" name="escolaridad" id="escolaridad" placeholder="Ingrese nivel de Escolaridad" runat="server"/>
        <input class="controls" type="text" name="plaza" id="plaza" placeholder="Ingrese nombre de Plaza" runat="server"/>

        <asp:LinkButton ID="btnguardar" class="botons" runat="server" OnClick="btnGuardar_Click">Guardar</asp:LinkButton>
        <asp:LinkButton ID="btnBuscar" class="botons" runat="server" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>
        <asp:LinkButton ID="btnEditar" class="botons" runat="server" OnClick="btnModificar_Click">Modificar</asp:LinkButton>
        <asp:LinkButton ID="btnEliminar" class="botons" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:LinkButton ID="btnLimpiar" class="botons" runat="server" OnClick="btnLimpiar_Click">Limpiar</asp:LinkButton>
    </section>
    </form>
</body>
</html>
