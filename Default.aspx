<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div style="right:0px; top: 98px; position: fixed;">
        <asp:LinkButton ID="CogLinkButton" CssClass="btn btn-default btn-sm" runat="server" OnClick="CogLinkButton_Click" ForeColor="#333333" title="Click to change Theme"><span class="glyphicon glyphicon-cog gly-spin" style="font-size: 1.9em;"></span></asp:LinkButton>
    </div>
    <div>
        <h1 class="text">Hello, Welcome to The Library Collection!</h1><br/>
        <p class="paragraph">This is a home e-Library having books from various categories around the world!</p><br/>
        <p class="paragraph">The website allows you to View, Add and Search for books.</p><br/>
        <p class="paragraph">Click on the Menu to your top left corner to explore! <br/>
            Use the same Menu to navigate to any page at any point of time.</p><br/>
     </div>    
</div>
</asp:Content>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
