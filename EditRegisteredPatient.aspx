<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditRegisteredPatient.aspx.cs" Inherits="EditRegisteredPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" xmlns:asp="#unknown">
    <div>
        <fieldset>
            <legend><b>Patient Registration</b></legend>
            <table colspan="9">
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="PRN" Text="PRN" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox CssClass="myInput" runat="server" ID="prntxt" /></td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="fn" Text="First Name *" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <asp:TextBox CssClass="myInput" runat="server" ID="fntxt" />
                        <asp:RequiredFieldValidator ID="reqfn" runat="server" ControlToValidate="fntxt" ErrorMessage=" Enter First Name" EnableClientScript="false" ForeColor="Red" />       
                    </td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="mn" Text="Middle Name" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox CssClass="myInput" runat="server" ID="mntxt" /></td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="ln" Text="Last Name *" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <asp:TextBox CssClass="myInput" runat="server" ID="lntxt" />
                        <asp:RequiredFieldValidator ID="reqlname" runat="server" ControlToValidate="lntxt" ErrorMessage="Enter Last Name" EnableClientScript="false" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3"><asp:Label runat="server" ID="doblbl" Text="Date Of Birth * (mm/dd/yyyy)" /></td>
                </tr>
                <tr>
                    <td colspan="1">Date</td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <asp:TextBox ID="dateofbirth" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="agelbl" Text="Age" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1" runat="server">
                        <asp:Label ID="agetxt" runat="server"></asp:Label>
                        <asp:Label runat="server" ID="yearlbl" Text="Years" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="nrclbl" Text="NRC *" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <asp:TextBox CssClass="myInput" runat="server" ID="nrctxt" />
                        <asp:RequiredFieldValidator ID="reqnrc" runat="server" ControlToValidate="nrctxt" ErrorMessage="Enter NRC" EnableClientScript="false" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="phnolbl" Text="Phone Number *" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <asp:TextBox CssClass="myInput" runat="server" ID="phtxt" />
                        <asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="phtxt" ErrorMessage="Enter Phone number" EnableClientScript="false" ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="vldph" runat="server" ControlToValidate="phtxt" ValidationExpression="\d{11}" ErrorMessage="Please enter correct phone number"  EnableClientScript="false" ForeColor="Red" />        
                    </td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="addresslbl" Text="Address" /></td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="homenolbl" Text="Home No" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox CssClass="myInput" runat="server" ID="homenotxt" /><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="homenotxt" ErrorMessage="Enter Correct Home Number" MaximumValue="1000" MinimumValue="1" Type="Integer" EnableClientScript="false" ForeColor="Red" /></td>
                    <td colspan="1"><asp:Label runat="server" ID="streetlbl" Text="Street" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox CssClass="myInput" runat="server" ID="streettxt" /></td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="statelbl" Text="State" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox ID="txtStates" runat="server"></asp:TextBox></td>
                    <td colspan="1"><asp:Label runat="server" ID="townshiplbl" Text="Township" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox ID="txtTownship" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="countrylbl" Text="Country" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox CssClass="myInput" runat="server" ID="countrytxt" Text="Myanmar"/></td>
                </tr>
<%--                <tr>
                    <td colspan="9" style="text-align:right">
                        <asp:Button CssClass="button1 backbutton" runat="server" ID="backreg" Text="Back" OnClick="backbtn"/>
                        <asp:Button CssClass="button1 backbutton" runat="server" ID="savebtreg" Text="Register" OnClick="registerbtn" />
                        <asp:Button CssClass="button1 backbutton" runat="server" ID="resetreg" Text="Reset" OnClick="resetall"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="9" style="text-align:right">
                        <asp:Button CssClass="button1 backbutton" runat="server" ID="cancelreg" Text="Cancel" OnClientClick="javascript:window.close();"/>
                    </td>
                </tr>--%>
            </table>
        </fieldset>
    </div>
</asp:Content>
