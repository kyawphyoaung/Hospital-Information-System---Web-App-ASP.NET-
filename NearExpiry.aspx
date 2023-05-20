<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NearExpiry.aspx.cs" Inherits="NearExpiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="2">
            <tr style="height:30px">
                <td>
                    <h3 style="line-height:15px">Near Expiry Report</h3>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvReorderLevel" runat="server" DataKeyNames="Code" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="170px" />
                            <asp:BoundField DataField="Generic" HeaderText="Generic" HeaderStyle-Width="170px" />
                            <asp:BoundField DataField="Forms" HeaderText="Forms" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Route" HeaderText="Drug Route" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Strength" HeaderText="Strength" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry Date" DataFormatString="{0:d}" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock On Hand" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                            <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" />
                            <asp:ImageField DataImageUrlField="Active" DataImageUrlFormatString="~\Active\{0}" HeaderText="Active" ControlStyle-Height="17px" ControlStyle-Width="17px" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:right">
                    <asp:Button CssClass="button1 backbutton" ID="btnBackToReports" runat="server" Text="Back" OnClick="BackToReports" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

