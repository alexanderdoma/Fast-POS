<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="Fast_POS._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:3rem">Listado de productos</h1>
    <asp:TextBox ID="txtConsulta" runat="server"></asp:TextBox>
    <asp:Button ID="btnFiltrar" OnClick="FiltrarProductos" runat="server" Text="Filtrar" />

    
    <asp:GridView ID="gvDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="14px" class="gvDatos">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <div class="productos">
        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>
                <div class="producto">
                    <h3><%#Eval("Nombre") %></h3>
                    <p><%# Eval("Marca") %></p>
                    <p><%# Eval("Precio") %></p>
                    <p><%# Eval("Categoria") %></p>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Editar Producto"  Width="200px" />
                    <asp:Button ID="Button2" runat="server" Text="Eliminar Producto" Width="200px" />
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
