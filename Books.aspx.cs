using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
public partial class Books : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        OracleConnection oConn = GetConnection();        
        OracleCommand oCmd = new OracleCommand("SELECT BOOK_ID, NAME, (SELECT NAME FROM AUTHOR WHERE AUTHOR_ID = b.AUTHOR_ID) AUTHOR, ISBN_NUMBER FROM BOOKS b ", oConn);        
        try
        {            
            oConn.Open();
            OracleDataReader reader = oCmd.ExecuteReader();
            if(reader.FetchSize > 0)
            {
                grid.DataSource = reader;
                grid.DataBind();
                reader.Close();
            }            
            else
            {
                displayLabel.Text = "No books are added to the library yet!";
            }
        }
        finally
        {
            oConn.Close();
        }
    }

    protected void addBookBtnId_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBook.aspx");
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
