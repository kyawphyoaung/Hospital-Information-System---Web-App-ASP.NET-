<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editpatient.aspx.cs" Inherits="editpatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <!-- Patinet Name -->
        <asp:Label runat="server" ID="patname" Text="Patient Name" />
        <br />

        <asp:Label runat="server" ID="fn" Text="First Name*" />
        <asp:TextBox runat="server" ID="fntxt" />
        <asp:RequiredFieldValidator ID="reqfname" runat="server" ControlToValidate="fntxt" ErrorMessage="Enter First Name" EnableClientScript="false" />
       
        <asp:Label runat="server" ID="mn" Text="Middle Name" />
        <asp:TextBox runat="server" ID="mntxt" />

        <asp:Label runat="server" ID="ln" Text="Last Name*" />
        <asp:TextBox runat="server" ID="lntxt" />
        <asp:RequiredFieldValidator ID="reqlname" runat="server" ControlToValidate="lntxt" ErrorMessage="Enter Last Name" EnableClientScript="false" />
       
        <br />
        <br />

        <!-- Gender -->
        <asp:Label runat="server" ID="gender" Text="Gender" />
        <asp:RadioButton runat="server" ID="male"   Text ="Male"  GroupName="gender"/>
        <asp:RadioButton runat="server" ID="female" Text="Female" GroupName="gender"/>
        <asp:RadioButton runat="server" ID="other"  Text="Others" GroupName="gender"/>
        <br />
        <br />

        <!-- DOB -->
        <asp:Label runat="server" ID="doblbl" Text="DateOfBirth* (mm/dd/yyyy)" /> <br />     
        <asp:TextBox ID="dob" runat="server" AutoPostBack="true" Text="1/1/2000" />
        <asp:RequiredFieldValidator ID="reqdob" runat="server" ControlToValidate="dob" ErrorMessage="Choose Date" EnableClientScript="false" />
       
        <asp:LinkButton ID="linkpickdate" runat="server" OnClick="visibleon">View Calendar</asp:LinkButton>
        <asp:Calendar runat="server" ID="datepick" OnSelectionChanged="Datechange" Visible="false" AutoPostBack="false" />
        <asp:Label runat="server" ID="agelbl" Text="Age" /> 
        <asp:TextBox ID="agetxt" runat="server" /> <!-- Age Text Box -->
        <asp:Label runat="server" ID="yearlbl" Text="year" />
        <br />
        <br />

        <!-- NRC -->
        <asp:Label runat="server" ID="nrclbl" Text="NRC*" /> <br />
        <asp:TextBox runat="server" ID="nrctxt" />
        <!-- Requirement Validate -->
        <asp:RequiredFieldValidator ID="reqnrc" runat="server" ControlToValidate="nrctxt" ErrorMessage="Enter NRC" EnableClientScript="false" />
       
        <br />

        <!-- Phone number -->
        <asp:Label runat="server" ID="phnolbl" Text="Phone Number*" /> <br />
        <asp:TextBox runat="server" ID="phtxt" />
        <!-- Requirement Validate -->
        <asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="phtxt" ErrorMessage="Enter Phone number" EnableClientScript="false" />
        <!-- Correct Phone no  -->
        <asp:RegularExpressionValidator ID="vldph" runat="server" ControlToValidate="phtxt" ValidationExpression="\d{11}" ErrorMessage="Please Correct Phnoe Number"  EnableClientScript="false" />        
        
        <br />
        <br />

        <!-- Address -->
        <asp:Label runat="server" ID="addrsslbl" Text="Address" /> <br />
        <asp:Label runat="server" ID="homnolbl" Text="Home No" />
        <asp:TextBox runat="server" ID="homenotxt" /> <!-- Homeno -->

        <!-- Validate Range of Home No -->
        <asp:RangeValidator ID="vldhom" runat="server" ControlToValidate="homenotxt" ErrorMessage="Enter Correct Home Number" MaximumValue="1000" MinimumValue="1" Type="Integer" EnableClientScript="false"/>

        <asp:Label runat="server" ID="streetlbl" Text="Street" />
        <asp:TextBox runat="server" ID="streettxt" /> <br /> <!-- Street -->
        
        <asp:Label runat="server" ID="statelbl" Text="State" />
        <asp:DropDownList ID="state" runat="server" AutoPostBack="true" AppendDataBoundItems="true" /> <!-- State -->
        <asp:Label runat="server" ID="townshiplbl" Text="Township" />
        <asp:DropDownList ID="township" runat="server" /> <!-- Township -->
        <asp:Label runat="server" ID="country" Text="Country" />
        <asp:TextBox runat="server" ID="countrytxt" Text="Myanmar"/> <!-- Country -->
        <br />
</asp:Content>

