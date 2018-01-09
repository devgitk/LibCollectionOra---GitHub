using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
/*
Name: Keshav Sridhara
Student No: 300948195
*/
public partial class AddBook : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void saveBtnId_Click(object sender, EventArgs e)
    {
                
        System.Diagnostics.Debug.WriteLine("IS THE PAGE VALID:::: " + Page.IsValid);

        if (Page.IsValid)
        {
            System.Diagnostics.Debug.WriteLine("VALID PAGE");
                        
            OracleConnection oConn = GetConnection();
            OracleCommand oCmd = oConn.CreateCommand();
            oCmd.CommandText = "INSERT_BOOKS_PRC";
            oCmd.CommandType = CommandType.StoredProcedure;

            OracleParameter param1 = oCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2, ParameterDirection.Input);
                param1.Value = bookNameWuc.Text;

            OracleParameter param2 = oCmd.Parameters.Add("P_AUTHOR", OracleDbType.Varchar2, ParameterDirection.Input);
                param2.Value = bookAuthorWuc.Text;

            OracleParameter param3 = oCmd.Parameters.Add("P_ISBN_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input);
                param3.Value = ((bookISBNWuc.Text == null) ? "" : bookISBNWuc.Text);

            OracleParameter param4 = oCmd.Parameters.Add("P_GENRE", OracleDbType.Varchar2, ParameterDirection.Input);
                param4.Value = genreId.Text;

            OracleParameter param5 = oCmd.Parameters.Add("P_NO_OF_PAGES", OracleDbType.Int32, ParameterDirection.Input);
                param5.Value = Convert.ToInt32(pagesId.Text);

            OracleParameter param6 = oCmd.Parameters.Add("P_QTY", OracleDbType.Int32, ParameterDirection.Input);
                param6.Value = Convert.ToInt32(qtyId.Text);

            OracleParameter param7 = oCmd.Parameters.Add("P_COMMENTS", OracleDbType.Varchar2, ParameterDirection.Input);
                param7.Value = commentsId.Text;

            oCmd.Parameters.Add("OUT_ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
            oCmd.Parameters.Add("OUT_ERR_CODE", OracleDbType.Varchar2, ParameterDirection.Output);

            oCmd.Parameters["OUT_ERR_CODE"].Size = 500;
            oCmd.Parameters["OUT_ERR_MSG"].Size = 500;

            System.Diagnostics.Debug.WriteLine("*****INSIDE bookDetailsGrid_ItemUpdating:*****"+ (oCmd.Parameters["OUT_ERR_MSG"].Value));


            try
            {
                oConn.Open();
                oCmd.ExecuteNonQuery();
                CreateAuditInsertRecord(oCmd.Parameters, "INSERT_BOOKS_PRC");
                Response.Redirect("Books.aspx");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("*****Exception***** "+ex.Message);
                dbErrorMessage.Text =
                "Error while adding the book!" +
                "Please try again later, and/or change the entered data!" +
                "Error Code:  {0}" + oCmd.Parameters["OUT_ERR_CODE"].Value.ToString() +
                "Error  Msg:  {1}" + oCmd.Parameters["OUT_ERR_MSG"].Value.ToString();
            }
            finally
            {
                oConn.Close();
            }

        }
        else
        {
            System.Diagnostics.Debug.WriteLine("INVALID PAGE");
        }
    }

    protected void cancelBtnId_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBook.aspx");
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        if (Session["ThemeSessionValue"] != null)
        {
            Session["ThemeSessionValue"] = Page.Theme;

            Response.Redirect("Books.aspx");
            Server.Transfer(Request.Path);
        }
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
