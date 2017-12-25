using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
/*
Name: Keshav Sridhara
Student No: 300948195
*/
public partial class FriendDetails : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Inside Page_PreInit: " + Session["ThemeSessionValue"].ToString());

        if (Session["ThemeSessionValue"] != null)
        {
            Page.Theme = (String)Session["ThemeSessionValue"];
        }
        else
        {
            Session["ThemeSessionValue"] = "DarkTheme";
            Page.Theme = (string)Session["ThemeSessionValue"];
        }
    }

    private OracleConnection GetConnection()
    {
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["LibCollectionOracleCenCol"];
        string strConnString = conString.ConnectionString;
        return new OracleConnection(strConnString);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE FRIENDDETAILS:Page_Load*****");
        if (!IsPostBack)
        {
            BindDetails();
        }
    }

    private void BindDetails()
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE FRIENDDETAILS:BindDetails*****");

        int bookId = Convert.ToInt32(Request.QueryString["FRIEND_ID"]);
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = new OracleCommand(" SELECT NAME, COMMENTS FROM FRIEND WHERE FRIEND_ID =:Friend_ID ", oConn);
        oCmd.Parameters.Add(new OracleParameter("Friend_ID", bookId));
        try
        {
            oConn.Open();
            OracleDataReader reader = oCmd.ExecuteReader();
            friendDetailsGrid.DataSource = reader;
            friendDetailsGrid.DataKeyNames = new string[] { "Name" };
            friendDetailsGrid.DataBind();
            reader.Close();
        }
        finally
        {
            oConn.Close();
        }
    }
    protected void friendDetailsGrid_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE FRIENDDETAILS:friendDetailsGrid_ModeChanging*****");

        friendDetailsGrid.ChangeMode(e.NewMode);
        BindDetails();
    }

    protected void friendDetailsGrid_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("*****INSIDE FRIENDDETAILS:friendDetailsGrid_ItemDeleting*****");
        int bookId = Convert.ToInt32(Request.QueryString["Friend_ID"]);

        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = oConn.CreateCommand();
        oCmd.CommandText = "DELETE_FRIENDS_PRC";
        oCmd.CommandType = CommandType.StoredProcedure;

        OracleParameter param1 = oCmd.Parameters.Add("P_FRIEND_ID", OracleDbType.Int32, ParameterDirection.Input);
        param1.Value = bookId;

        oCmd.Parameters.Add("OUT_ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
        oCmd.Parameters.Add("OUT_ERR_CODE", OracleDbType.Varchar2, ParameterDirection.Output);

        oCmd.Parameters["OUT_ERR_CODE"].Size = 500;
        oCmd.Parameters["OUT_ERR_MSG"].Size = 500;

        System.Diagnostics.Debug.WriteLine("*****INSIDE friendDetailsGrid_ItemDeleting:*****" + (oCmd.Parameters["OUT_ERR_MSG"].Value));


        try
        {
            oConn.Open();
            oCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("*****Exception***** " + ex.Message);
            dbErrorMessage.Text =
            "Error while deleting friend!" +
            "Error Code:  {0}" + oCmd.Parameters["OUT_ERR_CODE"].Value.ToString() +
            "Error  Msg:  {1}" + oCmd.Parameters["OUT_ERR_MSG"].Value.ToString();
        }
        finally
        {
            oConn.Close();
        }

        deletedLabel.Text = "The friend is deleted successfully!";
        friendDetailsGrid.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetails();
        //Response.Redirect("Books.aspx");


    }

    protected void friendDetailsGrid_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

        int bookId = Convert.ToInt32(Request.QueryString["Friend_ID"]);
        TextBox newNameTextBox =
           (TextBox)friendDetailsGrid.FindControl("editNameTextBox");
        TextBox newCommentsTextBox =
           (TextBox)friendDetailsGrid.FindControl("editCommentsTextBox");

        string newName = newNameTextBox.Text;
        string newComments = newCommentsTextBox.Text;

        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = oConn.CreateCommand();
        oCmd.CommandText = "UPDATE_FRIENDS_PRC";
        oCmd.CommandType = CommandType.StoredProcedure;

        OracleParameter param0 = oCmd.Parameters.Add("P_FRIEND_ID", OracleDbType.Int32, ParameterDirection.Input);
        param0.Value = bookId;

        OracleParameter param1 = oCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2, ParameterDirection.Input);
        param1.Value = newName;
        
        OracleParameter param7 = oCmd.Parameters.Add("P_COMMENTS", OracleDbType.Varchar2, ParameterDirection.Input);
        param7.Value = newComments;

        oCmd.Parameters.Add("OUT_ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
        oCmd.Parameters.Add("OUT_ERR_CODE", OracleDbType.Varchar2, ParameterDirection.Output);

        oCmd.Parameters["OUT_ERR_CODE"].Size = 500;
        oCmd.Parameters["OUT_ERR_MSG"].Size = 500;

        System.Diagnostics.Debug.WriteLine("*****INSIDE friendDetailsGrid_ItemUpdating:*****" + (oCmd.Parameters["OUT_ERR_MSG"].Value));


        try
        {
            oConn.Open();
            oCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("*****Exception***** " + ex.Message);
            dbErrorMessage.Text =
            "Error while updating the friend!" +
            "Please try again later, and/or change the entered data!" +
            "Error Code:  {0}" + oCmd.Parameters["OUT_ERR_CODE"].Value.ToString() +
            "Error  Msg:  {1}" + oCmd.Parameters["OUT_ERR_MSG"].Value.ToString();
        }
        finally
        {
            oConn.Close();
        }

        deletedLabel.Text = "The friend details are updated successfully!";
        friendDetailsGrid.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetails();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Session["ThemeSessionValue"] != null)
        {
            Session["ThemeSessionValue"] = Page.Theme;

            Response.Redirect("Friends.aspx");
            Server.Transfer(Request.Path);
        }
    }

    protected void friendDetailsGrid_ItemCreated(object sender, EventArgs e)
    {
        // Test FooterRow to make sure all rows have been created
        if (friendDetailsGrid.FooterRow != null && friendDetailsGrid.Rows.Count > 0)
        {
            // The command bar is the last element in the Rows collection
            int commandRowIndex = friendDetailsGrid.Rows.Count - 1;
            DetailsViewRow commandRow = friendDetailsGrid.Rows[commandRowIndex];


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
