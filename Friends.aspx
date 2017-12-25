<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="Friends.aspx.cs" Inherits="Friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type='text/css'>
        body { background-image: url("App_Themes/DarkTheme/Images/bookshelves-932780_1920.jpg"); }
    </style>
    <div>
    <h1 class="RalewayFont paragraph"><b>Friends</b></h1> <asp:Button ID="addFriendBtnId" runat="server" CssClass="btn btn-secondary" Text="Add a friend" OnClick="addFriendBtnId_Click"/>
        <asp:GridView ID="grid" GridLines="Horizontal" EmptyDataText="No friends added to the library yet!" runat="server" AllowSorting="true" AutoGenerateColumns="False" Width="100%" CssClass="RalewayFont paragraph">
            <Columns>
                <asp:HyperLinkField DataTextField="Name" HeaderText="Name" HeaderStyle-Font-Size="Larger" DataNavigateUrlFields="Friend_ID" DataNavigateUrlFormatString="~/FriendDetails.aspx?Friend_ID={0}" DataTextFormatString="{0}" Text="Name" />                
                <asp:BoundField DataField="Comments" HeaderText="Comments" HeaderStyle-Font-Size="Larger" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="displayLabel" runat="server" CssClass="RalewayFont paragraph"/>
        <br />
    </div>
</asp:Content>

