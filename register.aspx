    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>jQuery UI Datepicker - Restrict date range</title>
    <link rel="stylesheet" href="Styles/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange:'-120:+0',

                onSelect: function (selectedDate) {
                    var
                    today = new Date().getTime(),
                    dob = new Date(selectedDate).getTime();
                    age = today - dob;
                    yoa = Math.floor(age / 1000 / 60 / 60 / 24 / 365.25); 
                    
                    document.getElementById('Age').value = yoa;
                }
            })
        })
    </script>
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
                    <td colspan="1"><asp:Label runat="server" ID="gender" Text="Gender" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <asp:RadioButton runat="server" ID="male"   Text="Male"  GroupName="gender"/>
                        <asp:RadioButton runat="server" ID="female" Text="Female" GroupName="gender"/>
                        <asp:RadioButton runat="server" ID="other"  Text="Others" GroupName="gender"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"><asp:Label runat="server" ID="doblbl" Text="Date Of Birth * (mm/dd/yyyy)" /></td>
                </tr>
                <tr>
                    <td colspan="1">Date</td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1">
                        <input class="myInput" type="text" id="datepicker" name="n_datepicker" clientidmode="static" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="agelbl" Text="Age" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1" runat="server">
                        <input type="text" id="Age" name="n_Age" />
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
                    <td colspan="1"><asp:DropDownList CssClass="myInput" ID="state" runat="server" AutoPostBack="true" AppendDataBoundItems="true" /></td>
                    <td colspan="1"><asp:Label runat="server" ID="townshiplbl" Text="Township" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:DropDownList CssClass="myInput" ID="township" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="1"><asp:Label runat="server" ID="countrylbl" Text="Country" /></td>
                    <td class="auto-style1" colspan="1">:</td>
                    <td colspan="1"><asp:TextBox CssClass="myInput" runat="server" ID="countrytxt" Text="Myanmar"/></td>
                </tr>
                <tr>
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
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
       
       <%--<div class="PRN">
        <!-- PRN -->
        <asp:Label runat="server" ID="Label1" Text="PRN" />
        <asp:TextBox runat="server" ID="prntxt" />
        <br />
        <br />
       </div> <!--PRN close -->
    
    <asp:Label runat="server" ID="patname" Text="Patient Name" />
    
               
                <asp:Label runat="server" ID="fn" Text="First Name*" />
                <asp:TextBox runat="server" ID="fntxt" />
                <asp:RequiredFieldValidator ID="reqfname" runat="server" ControlToValidate="fntxt" ErrorMessage="Enter First Name" EnableClientScript="false" />       

                <asp:Label runat="server" ID="mn" Text="Middle Name" />
                <asp:TextBox runat="server" ID="mntxt" />
            
                <asp:Label runat="server" ID="ln" Text="Last Name*" />
                <asp:TextBox runat="server" ID="lntxt" />
                <asp:RequiredFieldValidator ID="reqlname" runat="server" ControlToValidate="lntxt" ErrorMessage="Enter Last Name" EnableClientScript="false" />
            --%>

    <%--   <div class="Gender" -->
        <!-- Gender -->
        <asp:Label runat="server" ID="gender" Text="Gender" />
        <asp:RadioButton runat="server" ID="male"   Text ="Male"  GroupName="gender"/>
        <asp:RadioButton runat="server" ID="female" Text="Female" GroupName="gender"/>
        <asp:RadioButton runat="server" ID="other"  Text="Others" GroupName="gender"/>
        <br />
        <br />
       </div> <!--Gender Close-->--%>
        
       <%--<div class="DOB">
        <!-- DOB -->
        <asp:Label runat="server" ID="doblbl" Text="DateOfBirth* (mm/dd/yyyy)" /> <br />     

        <p>Date: <input type="text" id="datepicker" name="datepicker" runat="server" clientidmode="static" /></p>
        
        <asp:Label runat="server" ID="agelbl" Text="Age" />
            
        <asp:TextBox ID="agetxt" runat="server" /> <!-- Age Text Box -->
        <asp:Label runat="server" ID="yearlbl" Text="year" />
        <br />
        <br />
       </div> <!-- DOB close -->--%>

<%--       <div class="NRC">
        <!-- NRC -->
        <asp:Label runat="server" ID="nrclbl" Text="NRC*" />
        <asp:TextBox runat="server" ID="nrctxt" />
        <!-- Requirement Validate -->
        
        <asp:RequiredFieldValidator ID="reqnrc" runat="server" ControlToValidate="nrctxt" ErrorMessage="Enter NRC" EnableClientScript="false" />
       
        <br />
       </div> <!-- NRC close -->--%>
        
<%--       <div class="phonenumber">
        <!-- Phone number -->
        <asp:Label runat="server" ID="phnolbl" Text="Phone Number*" />
        <asp:TextBox runat="server" ID="phtxt" />
        <!-- Requirement Validate -->
        <asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="phtxt" ErrorMessage="Enter Phone number" EnableClientScript="false" />
        <!-- Correct Phone no  -->
        <asp:RegularExpressionValidator ID="vldph" runat="server" ControlToValidate="phtxt" ValidationExpression="\d{11}" ErrorMessage="Please Correct Phnoe Number"  EnableClientScript="false" />        
        
        <br />
        <br />
       </div> <!--Phone Number Close -->--%>
        
<%--       <div class="address">
        <!-- Address -- -->
        <asp:Label runat="server" ID="addresslbl" Text="Address" /> <br />
        <asp:Label runat="server" ID="homenolbl" Text="Home No" />
        <asp:TextBox runat="server" ID="homenotxt" /> <!-- Homeno -->
       
        <!-- Validate Range of Home No -->
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="homenotxt" ErrorMessage="Enter Correct Home Number" MaximumValue="1000" MinimumValue="1" Type="Integer" EnableClientScript="false"/>

        <asp:Label runat="server" ID="streetlbl" Text="Street" />
        <asp:TextBox runat="server" ID="streettxt" /> <br /> <!-- Street -->
        
        <asp:Label runat="server" ID="statelbl" Text="State" />
        <asp:DropDownList ID="state" runat="server" AutoPostBack="true" AppendDataBoundItems="true" /> <!-- State -->
        <asp:Label runat="server" ID="twonshiplbl" Text="Township" />
        <asp:DropDownList ID="township" runat="server" /> <!-- Township -->
        <asp:Label runat="server" ID="countrylbl" Text="Country" />
        <asp:TextBox runat="server" ID="countrytxt" Text="Myanmar"/> <!-- Country -->
        <br />
       </div> <!--address close -->--%>

<%--       <div class="button">
        <!-- Button -->
        <asp:Button runat="server" ID="backreg" Text="Back" OnClick="backbtn"/>
        <asp:Button runat="server" ID="savebtreg" Text="Register" OnClick="registerbtn" />
        <asp:Button runat="server" ID="resetreg" Text="Reset" OnClick="resetall"/>
        <asp:Button runat="server" ID="cancelreg" Text="Cancel" OnClientClick="javascript:window.close();"/>
        
       </div> <!-- button close-->
      </div> <!-- container -->  --%>
    


