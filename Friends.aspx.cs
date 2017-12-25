using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Configuration;
public partial class Friends : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private OracleConnection GetConnection()
    {
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["LibCollectionOracleCenCol"];
        string strConnString = conString.ConnectionString;
        return new OracleConnection(strConnString);
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

    private void BindGrid()
    {
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = new OracleCommand("SELECT FRIEND_ID, NAME, COMMENTS  FROM FRIEND", oConn);
        try
        {
            oConn.Open();
            OracleDataReader reader = oCmd.ExecuteReader();
            if (reader.FetchSize > 0)
            {
                grid.DataSource = reader;
                grid.DataBind();
                reader.Close();
            }
            else
            {
                displayLabel.Text = "No friends are added yet!";
            }
        }
        finally
        {
            oConn.Close();
        }
    }

    protected void addFriendBtnId_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddFriend.aspx");
    }
}