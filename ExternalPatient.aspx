<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExternalPatient.aspx.cs" Inherits="ExternalPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <fieldset>
            <legend><b>External Patient :</b></legend>
        <table colspan="3">
            <tr>
                <td>Patient ID</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox CssClass="myInput" ID="txtPatientID" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name *</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox CssClass="myInput" ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone Number *</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox CssClass="myInput" ID="txtPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox CssClass="myInput" ID="txtEmail" runat="server"></asp:TextBox></td>
                <asp:RegularExpressionValidator CssClass="validation_error" ID="regexEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^\w+@[a-z]+\.(com)$" EnableClientScript="false" ErrorMessage="Your email is not in correct format." />
            </tr>
            <tr>
                <td>Address *</td>
                <td class="auto-style1">:</td>
                <td><asp:TextBox CssClass="myInput" ID="txtAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right"><asp:Button CssClass="button1" ID="btnConfirm" runat="server" Text="Confirm" OnClick="Confirm" />
                <asp:Button CssClass="button1" ID="btnBack" runat="server" Text="Back" OnClick="Back" /></td>
            </tr>
        </table>
        </fieldset>
    </div>
</asp:Content>

