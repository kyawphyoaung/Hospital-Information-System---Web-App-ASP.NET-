<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Generic.aspx.cs" Inherits="Generic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table colspan="5">
        <tr style="height:30px">
            <td colspan="2">
                <h3 style="line-height:15px">Generic</h3>
            </td>
            <td colspan="3" style="text-align:right">
                <asp:Button CssClass="button1 createbutton" ID="btnCreateGeneric" runat="server" Text="Create" OnClick="LinkCreateGeneric" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="gvGeneric" runat="server" DataSourceID="SqlDS1" DataKeyNames="Code" AllowPaging="true" PageSize="10" AutoGenerateEditButton="true" AutoGenerateColumns="false" SelectedRowStyle-BackColor="#99ccff" HeaderStyle-Height="25px" >
                    <Columns>
                        <asp:BoundField DataField="Code" HeaderText="Code" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="500px" />
                        <asp:ImageField DataImageUrlField="Active" DataImageUrlFormatString="~\Active\{0}" HeaderText="Active" ControlStyle-Height="17px" ControlStyle-Width="17px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:right">
                <asp:Button CssClass="button1 backbutton" ID="btnBackToMaster" runat="server" Text="Back" OnClick="BackToMasters" />
            </td>
        </tr>
    </table>
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true" SelectCommand ="SELECT * FROM Generic"></asp:SqlDataSource>
    </div>       
</asp:Content>

