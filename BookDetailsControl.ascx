<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookDetailsControl.ascx.cs" Inherits="BookDetailsControl" %>
<!--
 Name: Keshav Sridhara
 Student No: 300948195
 -->
<script runat="server">
    public string LabelText
    {
        set
        {
            bookDetailsLbl.Text = value;
        }
    }
    public string Text
    {
        get
        {
            return bookDetailsTb.Text;
        }
    }
    public string ValidationGroup
    {
      get
      {
        return bookDetailsTb.ValidationGroup;
      }
      set
      {
        bookDetailsTb.ValidationGroup = value;
        RequiredFieldValidator1.ValidationGroup = value;
      }
    }
</script>
<p>
    <asp:Label ID="bookDetailsLbl" runat="server" Text="" Width="450" CssClass="paragraph"/>
    <asp:TextBox ID="bookDetailsTb" runat="server" Text="" Width="250" MaxLength="50" CssClass="RalewayFont form-control"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="bookDetailsTb" ErrorMessage="*" Font-Size="20px" ForeColor="Red"/>
</p>
<!--
 Name: Keshav Sridhara
 Student No: 300948195
 -->