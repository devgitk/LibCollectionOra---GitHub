using System;
using System.Collections.Generic;
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
public partial class BookDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE BOOKDETAILS:Page_Load******");
        if (!IsPostBack)
        {
            BindDetails();
        }
    }

    private void BindDetails()
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE BOOKDETAILS:BindDetails*****");

        int bookId = Convert.ToInt32(Request.QueryString["Book_ID"]);
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = new OracleCommand(" SELECT NAME, (SELECT NAME FROM AUTHOR WHERE AUTHOR_ID = b.AUTHOR_ID) AUTHOR, " +
                                               " ISBN_NUMBER, (SELECT NAME FROM GENRE WHERE GENRE_ID = b.GENRE_ID) GENRE, " +
                                               " NO_OF_PAGES, QUANTITY, COMMENTS FROM BOOKS b WHERE BOOK_ID =:Book_ID ", oConn);
        oCmd.Parameters.Add(new OracleParameter("Book_ID", bookId));
        try
        {
            oConn.Open();
            OracleDataReader reader = oCmd.ExecuteReader();
            bookDetailsGrid.DataSource = reader;
            bookDetailsGrid.DataKeyNames = new string[] { "Name" };
            bookDetailsGrid.DataBind();
            reader.Close();
        }
        finally
        {
            oConn.Close();
        }
    }
    protected void bookDetailsGrid_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE BOOKDETAILS:bookDetailsGrid_ModeChanging*****");

        bookDetailsGrid.ChangeMode(e.NewMode);
        BindDetails();
    }

    protected void bookDetailsGrid_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("*****INSIDE BOOKDETAILS:bookDetailsGrid_ItemDeleting*****");
        int bookId = Convert.ToInt32(Request.QueryString["Book_ID"]);

        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = oConn.CreateCommand();
        oCmd.CommandText = "DELETE_BOOKS_PRC";
        oCmd.CommandType = CommandType.StoredProcedure;

        OracleParameter param1 = oCmd.Parameters.Add("P_BOOK_ID", OracleDbType.Int32, ParameterDirection.Input);
        param1.Value = bookId;

        oCmd.Parameters.Add("OUT_ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
        oCmd.Parameters.Add("OUT_ERR_CODE", OracleDbType.Varchar2, ParameterDirection.Output);

        oCmd.Parameters["OUT_ERR_CODE"].Size = 500;
        oCmd.Parameters["OUT_ERR_MSG"].Size = 500;

        System.Diagnostics.Debug.WriteLine("*****INSIDE bookDetailsGrid_ItemDeleting:*****" + (oCmd.Parameters["OUT_ERR_MSG"].Value));


        try
        {
            oConn.Open();
            oCmd.ExecuteNonQuery();
            CreateAuditDeleteRecord(oCmd.Parameters, "DELETE_BOOKS_PRC");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("*****Exception***** " + ex.Message);
            dbErrorMessage.Text =
            "Error while deleting the book!" +
            "Error Code:  {0}" + oCmd.Parameters["OUT_ERR_CODE"].Value.ToString() +
            "Error  Msg:  {1}" + oCmd.Parameters["OUT_ERR_MSG"].Value.ToString();
        }
        finally
        {
            oConn.Close();
        }

        deletedLabel.Text = "The book is deleted successfully!";
        bookDetailsGrid.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetails();
        //Response.Redirect("Books.aspx");


    }

    protected void bookDetailsGrid_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

        int bookId = Convert.ToInt32(Request.QueryString["Book_ID"]);
        TextBox newNameTextBox =
           (TextBox)bookDetailsGrid.FindControl("editNameTextBox");
        TextBox newAuthorTextBox =
           (TextBox)bookDetailsGrid.FindControl("editAuthorTextBox");
        TextBox newISBNNumberTextBox =
           (TextBox)bookDetailsGrid.FindControl("editISBNNumberTextBox");
        TextBox newGenreTextBox =
           (TextBox)bookDetailsGrid.FindControl("editGenreTextBox");
        TextBox newNoOfPagesTextBox =
           (TextBox)bookDetailsGrid.FindControl("editNoOfPagesTextBox");
        TextBox newQuantityTextBox =
           (TextBox)bookDetailsGrid.FindControl("editQuantityTextBox");
        TextBox newCommentsTextBox =
           (TextBox)bookDetailsGrid.FindControl("editCommentsTextBox");

        string newName = newNameTextBox.Text;
        string newAuthor = newAuthorTextBox.Text;
        string newISBNNumber = newISBNNumberTextBox.Text;
        string newGenre = newGenreTextBox.Text;
        string newNoOfPages = newNoOfPagesTextBox.Text;
        string newQuantity = newQuantityTextBox.Text;
        string newComments = newCommentsTextBox.Text;

        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = oConn.CreateCommand();
        oCmd.CommandText = "UPDATE_BOOKS_PRC";
        oCmd.CommandType = CommandType.StoredProcedure;

        OracleParameter param0 = oCmd.Parameters.Add("P_BOOK_ID", OracleDbType.Int32, ParameterDirection.Input);
        param0.Value = bookId;

        OracleParameter param1 = oCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2, ParameterDirection.Input);
        param1.Value = newName;

        OracleParameter param2 = oCmd.Parameters.Add("P_AUTHOR", OracleDbType.Varchar2, ParameterDirection.Input);
        param2.Value = newAuthor;

        OracleParameter param3 = oCmd.Parameters.Add("P_ISBN_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input);
        param3.Value = ((newISBNNumber == null) ? "" : newISBNNumber);

        OracleParameter param4 = oCmd.Parameters.Add("P_GENRE", OracleDbType.Varchar2, ParameterDirection.Input);
        param4.Value = newGenre;

        OracleParameter param5 = oCmd.Parameters.Add("P_NO_OF_PAGES", OracleDbType.Int32, ParameterDirection.Input);
        param5.Value = Convert.ToInt32(newNoOfPages);

        OracleParameter param6 = oCmd.Parameters.Add("P_QTY", OracleDbType.Int32, ParameterDirection.Input);
        param6.Value = Convert.ToInt32(newQuantity);

        OracleParameter param7 = oCmd.Parameters.Add("P_COMMENTS", OracleDbType.Varchar2, ParameterDirection.Input);
        param7.Value = newComments;

        oCmd.Parameters.Add("OUT_ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
        oCmd.Parameters.Add("OUT_ERR_CODE", OracleDbType.Varchar2, ParameterDirection.Output);

        oCmd.Parameters["OUT_ERR_CODE"].Size = 500;
        oCmd.Parameters["OUT_ERR_MSG"].Size = 500;

        System.Diagnostics.Debug.WriteLine("*****INSIDE bookDetailsGrid_ItemUpdating:*****" + (oCmd.Parameters["OUT_ERR_MSG"].Value));


        try
        {
            oConn.Open();
            oCmd.ExecuteNonQuery();
            CreateAuditUpdateRecord(oCmd.Parameters, "UPDATE_BOOKS_PRC");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("*****Exception***** " + ex.Message);
            dbErrorMessage.Text =
            "Error while updating the book!" +
            "Please try again later, and/or change the entered data!" +
            "Error Code:  {0}" + oCmd.Parameters["OUT_ERR_CODE"].Value.ToString() +
            "Error  Msg:  {1}" + oCmd.Parameters["OUT_ERR_MSG"].Value.ToString();
        }
        finally
        {
            oConn.Close();
        }

        deletedLabel.Text = "The book details are updated successfully!";
        bookDetailsGrid.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetails();
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

    protected void bookDetailsGrid_ItemCreated(object sender, EventArgs e)
    {
        // Test FooterRow to make sure all rows have been created
        if (bookDetailsGrid.FooterRow != null && bookDetailsGrid.Rows.Count > 0)
        {
            // The command bar is the last element in the Rows collection
            int commandRowIndex = bookDetailsGrid.Rows.Count - 1;
            DetailsViewRow commandRow = bookDetailsGrid.Rows[commandRowIndex];


            // Look for the DELETE button
            DataControlFieldCell cell = (DataControlFieldCell)commandRow.Controls[0];
            foreach (Control ctl in cell.Controls)
            {
                Button button = ctl as Button;
                if (button != null)
                {
                    if (button.CommandName == "Delete")
                    {
                        button.ToolTip = "Click here to delete this record";
                        button.OnClientClick = "if (!confirm('Do you want to delete this record?')) return false;";
                    }
                }
            }


        }
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
