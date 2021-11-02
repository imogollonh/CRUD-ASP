<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Prueba.Views.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Menu para prueba</h1>
        <nav id="primary_nav_wrap">
            <ul>
                <li class="current-menu-item"><a href="#">Home</a></li>
                <li><a href="#">Mantenimientos</a>
                <ul>
                    <li><a href="mantenimientoCandidato.aspx">Candidatos</a></li>
                </ul>
                </li>
                <li><a href="#">Vistas</a>
                <ul>
                    <li><a href="vistaCandidatos.aspx">Candidatos</a></li>
                </ul>
                </li>
            </ul>
        </nav>
</body>
</html>
