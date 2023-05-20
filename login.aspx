<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <fieldset>
            <legend><b>Login</b></legend>
            <table colspan="3">
                <tr>
                    <!-- Username --> 
                    <td><asp:Label ID="usernamelbl" runat="server" Text="UserName" /></td>
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="usernametxt" runat="server" /><asp:RequiredFieldValidator ID="vldName" runat="server" ControlToValidate="usernametxt" ErrorMessage="Enter Username!" EnableClientScript="false" ForeColor="Red" /></td>
                </tr>
                <tr>
                    <!-- Password --> 
                    <td><asp:Label ID="password" runat="server" Text="Password" /></td>
                    <td class="auto-style1">:</td>
                    <td><asp:TextBox CssClass="myInput" ID="passwordtxt" runat="server" TextMode="Password" /><asp:RequiredFieldValidator ID="vldPsw" runat="server" EnableClientScript="false" ControlToValidate="passwordtxt" ErrorMessage="Enter Password!" ForeColor="Red" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:right">
                        <asp:Button CssClass="button1 createbutton" ID="loginbt" runat="server" OnClick="loginclick" Text="Log In" />
                        <asp:Button CssClass="button1 backbutton" ID="cancelbt" runat="server" OnClick="clearclick" Text="Clear" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:right">
                        <asp:Button CssClass="button1 backbutton" runat="server" ID="cancelreg" Text="Cancel" OnClientClick="javascript:window.close();"/>
                    </td>
                </tr>
            </table>
        </fieldset> 
    </div>
</asp:Content>

