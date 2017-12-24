using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
public partial class BookDetailsControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(bookDetailsLbl.Text == "Name:")
            bookDetailsTb.Attributes.Add("placeholder", "Name");
        if (bookDetailsLbl.Text == "Author(s):")
            bookDetailsTb.Attributes.Add("placeholder", "Author");
        if (bookDetailsLbl.Text == "ISBN Number:")
            bookDetailsTb.Attributes.Add("placeholder", "ISBN No. e.g., 123-456-7890");
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
