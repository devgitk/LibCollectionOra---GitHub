<%@ Page Language="C#" MasterPageFile="~/LibraryCollection.master" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="BookDetails" %>
<%--Name: Keshav Sridhara
Student No: 300948195--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">            
        <style type='text/css'>
            body { background-image: url("App_Themes/DarkTheme/Images/bookshelves-932780_1920.jpg"); }

        </style>
        <asp:LinkButton ID="btnBack" runat="server" style="font-size:x-large; padding-top:30px; padding-left:900px;" CssClass="textColor" OnClick="btnHome_Click" >
            <span aria-hidden="true" style="padding-top:30px; padding-left:30px;" class="glyphicon glyphicon-circle-arrow-left" title="Back"></span>
        </asp:LinkButton>
        <h1 class="RalewayFont paragraph"><b>Book Details</b></h1>
        <asp:DetailsView ID="bookDetailsGrid" runat="server" AutoGenerateRows="False" Width="75%" GridLines="None"
            CssClass="RalewayFont" OnModeChanging="bookDetailsGrid_ModeChanging" OnItemUpdating="bookDetailsGrid_ItemUpdating" OnItemDeleting="bookDetailsGrid_ItemDeleting" OnItemCreated="bookDetailsGrid_ItemCreated">
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
                <asp:TemplateField HeaderText="Author" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                            <asp:TextBox ID="editAuthorTextBox" runat="server" Text='<%# Bind("Author") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertAuthorTextBox" runat="server" Text='<%# Bind("Author") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="authorLabel" runat="server" Text='<%# Bind("Author") %>' CssClass="paragraph"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ISBN Number" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                        <asp:TextBox ID="editISBNNumberTextBox" runat="server" Text='<%# Bind("ISBN_Number") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertISBNNumberTextBox" runat="server" Text='<%# Bind("ISBN_Number") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="isbnNumberLabel" runat="server" Text='<%# Bind("ISBN_Number") %>' CssClass="paragraph"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Genre" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                            <asp:TextBox ID="editGenreTextBox" runat="server" Text='<%# Bind("Genre") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertGenreTextBox" runat="server" Text='<%# Bind("Genre") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="genreNumberLabel" runat="server" Text='<%# Bind("Genre") %>' CssClass="paragraph"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No of pages" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                            <asp:TextBox ID="editNoOfPagesTextBox" runat="server" Text='<%# Bind("No_Of_Pages") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertNoOfPagesTextBox" runat="server" Text='<%# Bind("No_Of_Pages") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="10"></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="noOfPagesNumberLabel" runat="server" Text='<%# Bind("No_Of_Pages") %>' CssClass="paragraph"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Name: Keshav Sridhara
                Student No: 300948195--%>                              
                <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="paragraph">
                    <EditItemTemplate>
                        <p>
                            <asp:TextBox ID="editQuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <p>
                            <asp:TextBox ID="insertQuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' CssClass="RalewayFont form-control" Width="250" MaxLength="50"></asp:TextBox>
                        </p>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="quantityLabel" runat="server" Text='<%# Bind("Quantity") %>' CssClass="paragraph"></asp:Label>
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
<%--Name: Keshav Sridhara
Student No: 300948195--%>