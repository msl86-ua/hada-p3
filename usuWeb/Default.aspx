<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="usuWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <p>
 NIF:<asp:TextBox id="userTextBox" TextMode="SingleLine"
 Columns="30" runat="server" style="height: 22px" />
</p>
        Nombre: <asp:TextBox id="NombreTextBox"
 TextMode="SingleLine" Columns="30" runat="server" />
        <p>
       Edad: <asp:TextBox id="TextBox1"
 TextMode="SingleLine" Columns="30" runat="server" />
</p>

     <asp:Button text="Leer" onClick="whenLeer" ID="buttom_Leer" runat="server"  />
    <asp:Button text="Leer Primero" onClick="whenPrimero" ID="buttom_Primero" runat="server" />
    <asp:Button text="Leer Anterior" onClick="whenAnterior" ID="buttom_Anterior" runat="server" />
    <asp:Button text="Leer Siguiente" onClick="whenSiguiente" ID="buttom_Siguiente" runat="server" />
    <asp:Button text="Crear" onClick="whenCrear" ID="buttom_Crear" runat="server" />
    <asp:Button text="Actualizar" onClick="whenActualizar" ID="buttom_Actualizar" runat="server" />
    <asp:Button text="Borrar" onClick="whenBorrar" ID="buttom_Borrar" runat="server" />
</asp:Content>
