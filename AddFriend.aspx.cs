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
public partial class AddFriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private OracleConnection GetConnection()
    {
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["LibCollectionOracleCenCol"];
        string strConnString = conString.ConnectionString;
        return new OracleConnection(strConnString);
    }

    protected void saveBtnId_Click(object sender, EventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("IS THE PAGE VALID:::: " + Page.IsValid);

        if (Page.IsValid)
        {
            System.Diagnostics.Debug.WriteLine("VALID PAGE");

            OracleConnection oConn = GetConnection();
            OracleCommand oCmd = oConn.CreateCommand();
            oCmd.CommandText = "INSERT_FRIENDS_PRC";
            oCmd.CommandType = CommandType.StoredProcedure;

            OracleParameter param4 = oCmd.Parameters.Add("P_NAME", OracleDbType.Varchar2, ParameterDirection.Input);
            param4.Value = nameId.Text;

            OracleParameter param7 = oCmd.Parameters.Add("P_COMMENTS", OracleDbType.Varchar2, ParameterDirection.Input);
            param7.Value = commentsId.Text;

            oCmd.Parameters.Add("OUT_ERR_MSG", OracleDbType.Varchar2, ParameterDirection.Output);
            oCmd.Parameters.Add("OUT_ERR_CODE", OracleDbType.Varchar2, ParameterDirection.Output);

            oCmd.Parameters["OUT_ERR_CODE"].Size = 500;
            oCmd.Parameters["OUT_ERR_MSG"].Size = 500;

            System.Diagnostics.Debug.WriteLine("*****INSIDE friendDetailsGrid_ItemUpdating:*****" + (oCmd.Parameters["OUT_ERR_MSG"].Value));


            try
            {
                oConn.Open();
                oCmd.ExecuteNonQuery();
                Response.Redirect("Friends.aspx");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("*****Exception***** " + ex.Message);
                dbErrorMessage.Text =
                "Error while adding the friend!" +
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
        Response.Redirect("AddFriend.aspx");
    }

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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Session["ThemeSessionValue"] != null)
        {
            Session["ThemeSessionValue"] = Page.Theme;

            Response.Redirect("Friends.aspx");
            Server.Transfer(Request.Path);
        }
    }
    
}
/*
Name: Keshav Sridhara
Student No: 300948195
*/
