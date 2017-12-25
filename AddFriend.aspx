<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="AddFriend.aspx.cs" Inherits="AddFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type='text/css'>

        body { background-image: url("App_Themes/DarkTheme/Images/bookcase-1867460_1920.jpg"); }
    </style>
    <div>
        <asp:LinkButton ID="btnBack" runat="server" style="font-size:x-large; padding-top:30px; padding-left:900px;" CssClass="textColor" OnClick="btnBack_Click" CausesValidation="false">
            <span aria-hidden="true" style="padding-top:30px; padding-left:30px;" class="glyphicon glyphicon-circle-arrow-left" title="Back"></span>
        </asp:LinkButton>
        <h1 class="text">Add a Friend</h1><br/>
        <div class="form-group form-inline">        
        <p>
            <asp:Label runat="server" Text="Name:" Width="450" CssClass="paragraph " /> <asp:TextBox ID="nameId" runat="server" Text="" Width="250" MaxLength="50" CssClass="RalewayFont form-control" placeholder="Name of the friend"/><br/>
        </p>        
        <p>
            <asp:Label runat="server" Text="Comments:" Width="450" CssClass="paragraph" /> <asp:TextBox ID="commentsId" runat="server" TextMode="MultiLine" placeholder="(Maximum characters: 100)" Width="250" MaxLength="200"  CssClass="RalewayFont form-control"/>
        </p>
        <p>
            <asp:Label runat="server" ID="dbErrorMessage" Text="" />
        </p>
        <p>
            <asp:Button runat="server" ID="saveBtnId" Text="Save" CssClass="RalewayFont form-control" OnClick="saveBtnId_Click"/> <asp:Button runat="server" ID="cancelBtnId" Text="Cancel" CssClass="RalewayFont form-control" OnClick="cancelBtnId_Click" CausesValidation="false"/>
        </p>
            </div>
     </div>
</asp:Content>

