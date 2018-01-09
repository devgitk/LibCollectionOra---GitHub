using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
public partial class Friends : BasePage
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