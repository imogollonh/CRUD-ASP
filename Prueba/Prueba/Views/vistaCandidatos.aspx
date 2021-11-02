<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vistaCandidatos.aspx.cs" Inherits="Prueba.Views.vistaCandidatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <!-- Estilos -->
    <link href="../css/formularioVistaCandidatos.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <title>Vista de candidatos</title>
</head>
<body>

    <center><asp:Label ID="lblerror" ForeColor="Red" runat="server" Text=""></asp:Label></center>
   <form runat="server">
        <header runat="server" class="form-register">
            <center><asp:LinkButton ID="regresar" class="botons" runat="server" OnClick="regresar_Click">Home</asp:LinkButton></center>
        </header>
        <section class="form-register">
       <h4>Vista Total de Candidatos</h4>
       <asp:GridView CssClass="table table-bordered table-condensed" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="pk_CUI" DataSourceID="SqlDataSource1" Width="985px">
           <Columns>
               <asp:BoundField DataField="pk_CUI" HeaderText="DPI" ReadOnly="True" SortExpression="pk_CUI" />
               <asp:BoundField DataField="nombres" HeaderText="Nombres" SortExpression="nombres" />
               <asp:BoundField DataField="apellidos" HeaderText="Apellidos" SortExpression="apellidos" />
               <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="direccion" />
               <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono" />
               <asp:BoundField DataField="escolaridad" HeaderText="Escolaridad" SortExpression="escolaridad" />
               <asp:BoundField DataField="plaza" HeaderText="Plaza" SortExpression="plaza" />
               <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
           </Columns>
       </asp:GridView>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mydbConnectionString2 %>" ProviderName="<%$ ConnectionStrings:mydbConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM mydb.tbl_candidato;"></asp:SqlDataSource>
       <br />
       <br />
       <asp:LinkButton ID="btnActualizar" class="botons" runat="server" >Actualizar</asp:LinkButton>
    </section>
    </form>
</body>
</html>
