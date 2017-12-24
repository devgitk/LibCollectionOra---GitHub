<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books"%>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type='text/css'>
        body { background-image: url("App_Themes/DarkTheme/Images/bookshelves-932780_1920.jpg"); }
    </style>
    <div>
    <h1 class="RalewayFont paragraph"><b>Books</b></h1> <asp:Button ID="addBookBtnId" runat="server" CssClass="btn btn-secondary" Text="Add Book" OnClick="addBookBtnId_Click"/>
        <asp:GridView ID="grid" GridLines="Horizontal" EmptyDataText="No books added to the library yet!" runat="server" AllowSorting="true" AutoGenerateColumns="False" Width="100%" CssClass="RalewayFont paragraph">
            <Columns>
                <asp:HyperLinkField DataTextField="Name" HeaderText="Name" HeaderStyle-Font-Size="Larger" DataNavigateUrlFields="Book_ID" DataNavigateUrlFormatString="~/BookDetails.aspx?Book_ID={0}" DataTextFormatString="{0}" Text="Name" />
                <%--<asp:BoundField DataField="Name" HeaderText="Name"/>--%>
                <asp:BoundField DataField="Author" HeaderText="Author" HeaderStyle-Font-Size="Larger"/>
                <asp:BoundField DataField="ISBN_Number" HeaderText="ISBN Number" HeaderStyle-Font-Size="Larger" />
                <%--<asp:ButtonField CommandName="Select" Text="Select" />--%>
            </Columns>
        </asp:GridView>
        <asp:Label ID="displayLabel" runat="server" CssClass="RalewayFont paragraph"/>
        <br />
    </div>
</asp:Content>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
