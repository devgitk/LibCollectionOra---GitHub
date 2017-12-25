<%@ Page Title="" Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="FriendDetails.aspx.cs" Inherits="FriendDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type='text/css'>
            body { background-image: url("App_Themes/DarkTheme/Images/bookshelves-932780_1920.jpg"); }

        </style>
        <asp:LinkButton ID="btnBack" runat="server" style="font-size:x-large; padding-top:30px; padding-left:900px;" CssClass="textColor" OnClick="btnBack_Click" >
            <span aria-hidden="true" style="padding-top:30px; padding-left:30px;" class="glyphicon glyphicon-circle-arrow-left" title="Back"></span>
        </asp:LinkButton>
        <h1 class="RalewayFont paragraph"><b>Friend Details</b></h1>
        <asp:DetailsView ID="friendDetailsGrid" runat="server" AutoGenerateRows="False" Width="75%" GridLines="None"
            CssClass="RalewayFont" OnModeChanging="friendDetailsGrid_ModeChanging" OnItemUpdating="friendDetailsGrid_ItemUpdating" OnItemDeleting="friendDetailsGrid_ItemDeleting" OnItemCreated="friendDetailsGrid_ItemCreated">
            <Fields>
                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                            <asp:TextBox ID="editNameTextBox" runat="server" Text='<%# Bind("Name") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertNameTextBox" runat="server" Text='<%# Bind("Name") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("Name") %>' CssClass="paragraph"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comments" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                            <asp:TextBox ID="editCommentsTextBox" runat="server" Text='<%# Bind("Comments") %>' CssClass="RalewayFont form-control" Width="250" TextMode="MultiLine" placeholder="(Maximum characters: 100)" MaxLength="200" ></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertCommentsTextBox" runat="server" Text='<%# Bind("Comments") %>' CssClass="RalewayFont form-control" Width="250" TextMode="MultiLine" placeholder="(Maximum characters: 100)" MaxLength="200" ></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="commentsLabel" runat="server" Text='<%# Bind("Comments") %>' CssClass="paragraph"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:CommandField  ButtonType="Button" ShowDeleteButton="true" DeleteText="Delete" 
                ControlStyle-CssClass="btn btn-secondary" ShowEditButton="true" EditText="Edit"/>
            </Fields>
        </asp:DetailsView>
    <asp:Label ID="deletedLabel" runat="server" CssClass="RalewayFont paragraph"></asp:Label>
    <p>
            <asp:Label runat="server" ID="dbErrorMessage" Text="" />
    </p>
</asp:Content>

