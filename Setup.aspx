<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Setup.aspx.cs" Inherits="Setup" %>

<!DOCTYPE html>
<!--Name: Keshav Sridhara
Student No: 300948195-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Theme Setup Page</title>
    <link rel="stylesheet" href="App_Themes/Library/bootstrap-3.3.0/dist/css/bootstrap.min.css"/>       <!-- Bootstrap Lib-->
    <script src="App_Themes/Library/jquery-3.1.0.min.js"></script>                                      <!-- jQuery Lib-->
    <script src="App_Themes/Library/bootstrap-3.3.0/dist/js/bootstrap.min.js"></script>    
    <link href="https://fonts.googleapis.com/css?family=Lobster|Raleway:600i" rel="stylesheet"/>         <!-- Google Fonts-->
    <link rel="stylesheet" href="App_Themes/Library/bootstrap-3.3.0/dist/css/bootstrap-theme.min.css"/>
    <link rel="stylesheet" href="App_Themes/Global.css"/>
</head>
<body style="background-color:#131516">
    <form id="form1" runat="server">
        <asp:LinkButton ID="btnHome" runat="server" style="font-size:x-large; padding-top:30px; padding-left:30px; color:#8CFFFB" OnClick="homeClick_Click" >
            <span aria-hidden="true" style="padding-top:30px; padding-left:30px;" class="glyphicon glyphicon-home" title="Home"></span>
        </asp:LinkButton>
        <div class="container">
            <p>
                <asp:Button Text="Light Theme" runat="server" ID="lightButton" CssClass="btn btn-xl btn-sample-lighttheme" OnClick="lightTheme_Click"/>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button Text="Dark Theme" runat="server" ID="darkButton" CssClass="btn btn-xl btn-sample-darktheme" OnClick="darkTheme_Click"/>
            </p>            
        </div>
        <p class="Footer">
            <asp:Label runat="server" ID="CookieText"/>
        </p>
    </form>
</body>
</html>
<!--Name: Keshav Sridhara
Student No: 300948195-->