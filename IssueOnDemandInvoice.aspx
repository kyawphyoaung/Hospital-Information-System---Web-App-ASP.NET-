<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IssueOnDemandInvoice.aspx.cs" Inherits="IssueOnDemandInvoic" %>

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
            $('#register').on('click', function () {
                $('.register-popup').dialog('open');
            });
            $('.register-popup').dialog({
                autoOpen: false,
                modal: true,
                width: '1200',
                height: '650',
                title: 'Issue On Demand Invoice',
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div> <a href="#" id="register">Register</a></div>
    <div class="register-popup">
        <form>
            <img src ="Image/heading.png" height="170px" width="700px" /><br />
            <label for="fname"> First Name </label><br/>
            <input type="text" name="fname"/><br/><br/>
            <label for="fname"> First Name </label><br/>
            <input type="text" name="lname"><br/><br/>
        </form>
    </div>
</asp:Content>

