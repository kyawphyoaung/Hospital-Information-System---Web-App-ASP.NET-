<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SaleReports.aspx.cs" Inherits="SaleReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table colspan="2">
            <tr style="height:30px">
                <td>
                    <h3 style="line-height:15px">Sale Report</h3>
                </td>
            </tr>
            <tr>
                <td colspan="1">Stores : <asp:DropDownList ID="ddlStores" runat="server" DataSourceID="SqlDS1" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="DisplaySaleReport" AutoPostBack="false"></asp:DropDownList></td>
                <td colspan="1">
                    Within : <asp:DropDownList ID="ddlRange" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RangeSelected">
                                <asp:ListItem>Today</asp:ListItem>
                                <asp:ListItem>A Week</asp:ListItem>
                                <asp:ListItem>A Month</asp:ListItem>
                                <asp:ListItem>A Year</asp:ListItem>
                             </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvSaleReport" runat="server" AllowPaging="true" PageSize="10" DataKeyNames="IssueNumber" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                        <Columns>
                            <asp:BoundField DataField="PatientID" HeaderText="Patient ID" />
                            <asp:BoundField DataField="IssueNumber" HeaderText="Document Number" />
                            <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Store" HeaderText="Store" />
                            <asp:BoundField DataField="Code" HeaderText="Code" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" />
                            <asp:BoundField DataField="Expiry" HeaderText="Expiry Date" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="IssueStatus" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source = localhost; Initial Catalog = HospitalIS; Integrated Security = true;" SelectCommand ="SELECT Name FROM Stores"></asp:SqlDataSource>
    </div>
</asp:Content>

