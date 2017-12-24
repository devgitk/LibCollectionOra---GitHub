<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type='text/css'>
        body { 
            background-image: url("App_Themes/DarkTheme/Images/books-2582889_1920.jpg");               
        }
        
    </style>
    <div class="form-group form-inline">
        <h1 class="text">Search for Books.</h1><br/>
       <p>
            <asp:Label runat="server" Text="Genre:" Width="450" CssClass="paragraph"/> 
            <asp:DropDownList ID="searchGenreDdId" runat="server" Width="250" CssClass="RalewayFont form-control">
                <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label runat="server" Text="Name of the friend:" Width="450" CssClass="paragraph" /> 
            <asp:DropDownList ID="searchFriendNameDdId" runat="server" Width="250" CssClass="RalewayFont form-control">
                <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
            </asp:DropDownList><br/>
        </p>
        <p>
            <asp:Button runat="server" ID="searchBtnId" Text="Search" CssClass="RalewayFont form-control" Width="20%" OnClick="searchBtnId_Click"/> <asp:Button runat="server" ID="resetBtnId" Text="Reset" CssClass="RalewayFont form-control" Width="20%" OnClick="resetBtnId_Click" CausesValidation="false"/>
        </p>
     </div>
     <asp:GridView ID="searchedItemsGrid" runat="server" GridLines="Horizontal"  AllowSorting="true" AutoGenerateColumns="False" Width="120%" CssClass="RalewayFont paragraph">
        <Columns>            
            <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Font-Size="Larger" />
            <asp:BoundField DataField="Author" HeaderText="Author" HeaderStyle-Font-Size="Larger" />
            <%--<asp:BoundField DataField="ISBN_Number" HeaderText="ISBN Number"/>--%>
            <asp:BoundField DataField="Genre" HeaderText="Genre" HeaderStyle-Font-Size="Larger"/>
            <asp:BoundField DataField="Name_Of_Friend" HeaderText="Name of friend" HeaderStyle-Font-Size="Larger" />
        </Columns>
     </asp:GridView>
</asp:Content>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
