<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="patientlist.aspx.cs" Inherits="patientlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="refershgv" runat="server" Text="Refersh" OnClick="refershall" />
    <asp:GridView ID="gv" runat="server" AutoGenerateSelectButton="true" DataKeyNames="PatientID" OnSelectedIndexChanged="SelChanged" ></asp:GridView>
    <br />

  <%--  <asp:SqlDataSource ID="productDataSource" Runat="server"
            SelectCommand="SELECT [ProductName], [ProductID],[UnitPrice], [UnitsInStock] FROM [Products]"
            UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [UnitPrice] = @UnitPrice [UnitsInStock] = @UnitsInStock WHERE [ProductID] = @original_ProductID"
            ConnectionString="<%$ ConnectionStrings:NWConnectionString %>">

            <UpdateParameters>
                <asp:Parameter Type="String" Name="ProductName"></asp:Parameter>
                <asp:Parameter Type="Decimal" Name="UnitPrice"></asp:Parameter>
                <asp:Parameter Type="Int16" Name="UnitsInStock"></asp:Parameter>
                <asp:Parameter Type="Int32" Name="ProductID"></asp:Parameter>
            </UpdateParameters>

     </asp:SqlDataSource>

    <asp:GridView ID="GridView1" Runat="server" DataSourceID="productDataSource" DataKeyNames="ProductID" AutoGenerateColumns="False" AllowPaging="True" 
     BorderWidth="1px" BackColor="White" CellPadding="4" BorderStyle="None" BorderColor="#3366CC">
            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
            <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC"></PagerStyle>
            <HeaderStyle ForeColor="#CCCCFF" Font-Bold="True" BackColor="#003399"></HeaderStyle>

        <Columns>
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
            <asp:BoundField ReadOnly="True" HeaderText="ProductID" InsertVisible="False" DataField="ProductID" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField HeaderText="Product" DataField="ProductName" SortExpression="ProductName"></asp:BoundField>
            <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice" SortExpression="UnitPrice">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Units In Stock" DataField="UnitsInStock" SortExpression="UnitsInStock">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
        </Columns>

        <SelectedRowStyle ForeColor="#CCFF99" Font-Bold="True" BackColor="#009999"></SelectedRowStyle>
        <RowStyle ForeColor="#003399" BackColor="White"></RowStyle>

        </asp:GridView>--%>
    <asp:Button ID="backbtn" runat="server" Text="Back" OnClick="backhome" />
</asp:Content>

