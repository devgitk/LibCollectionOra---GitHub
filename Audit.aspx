<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LibraryCollection.master" CodeFile="Audit.aspx.cs" Inherits="Audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type='text/css'>

        body { background-image: url("App_Themes/DarkTheme/Images/bookcase-1867460_1920.jpg"); }
    </style>
    <div>
        <h1 class="text">Audit Log</h1><br/>
        <asp:GridView ID="grid" GridLines="Horizontal" AllowSorting="true" DataKeyNames="AUDIT_LOG_ID" EmptyDataText="No Audit data yet!" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="RalewayFont paragraph" OnSelectedIndexChanged="grid_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="METHOD" HeaderText="Operation" HeaderStyle-Font-Size="Larger"/>
                <asp:BoundField DataField="DESTINATION" HeaderText="Destination" HeaderStyle-Font-Size="Larger"/>
                <asp:BoundField DataField="IPADDRESS" HeaderText="IPAddress" HeaderStyle-Font-Size="Larger" />
                <asp:BoundField DataField="R_DATE" HeaderText="Date" HeaderStyle-Font-Size="Larger" />
                <asp:ButtonField CommandName="Select" Text="Select" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:DetailsView ID="gridDetail" runat="server" CssClass="RalewayFont paragraph"></asp:DetailsView>

     </div>
</asp:Content>
