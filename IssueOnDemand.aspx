<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IssueOnDemand.aspx.cs" Inherits="IssueOnDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table colspan="5">
        <tr style="height:30px;">
            <td colspan="2">
                <h3 style="line-height:15px">Issue On Demand</h3>
            </td>
            <td colspan="3" style="text-align:right">
                <asp:Button CssClass="button1" ID="btnCreate" runat="server" Text="Issue On Demand" OnClick="LinkCreateIssueOnDemand" Width="150px" Height="30px"/>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="gvIssueOnDemand" runat="server" DataSourceID="SqlDS1" AllowPaging="true" PageSize="10" DataKeyNames="IssueNumber" AutoGenerateColumns="false" HeaderStyle-Height="25px" RowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="PatientID" HeaderText="Patient ID" HeaderStyle-Width="100px" />
                    <asp:BoundField DataField="IssueNumber" HeaderText="Issue Number" HeaderStyle-Width="120px" />
                    <asp:BoundField DataField="IssueStatus" HeaderText="Status" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="Store" HeaderText="Store" HeaderStyle-Width="150px" />
                    <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" HeaderStyle-Width="100px" DataFormatString="{0:d}" />
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:right;">
                <asp:Button CssClass="button1 backbutton" ID="btnBackToPharmacy" runat="server" Text="Back" OnClick="BackToPharmacy" />
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDS1" runat="server" ConnectionString="Data Source=localhost; Initial Catalog=HospitalIS; Integrated Security = true;" SelectCommand="SELECT * FROM IssueOnDemand"></asp:SqlDataSource>
    </div>
</asp:Content>

