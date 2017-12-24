using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
public partial class Search : System.Web.UI.Page
{
    private OracleConnection GetConnection()
    {
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["LibCollectionOracleCenCol"];
        string strConnString = conString.ConnectionString;
        return new OracleConnection(strConnString);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   /*
            OracleConnection oConn = GetConnection();
            OracleCommand genreListCommand = new OracleCommand("SELECT DISTINCT(Genre) FROM Books WHERE Genre IS NOT NULL", oConn);
            OracleCommand FriendsListCommand = new OracleCommand("SELECT DISTINCT(Name_Of_Friend) FROM Books " +
                                                                 "WHERE Name_Of_Friend IS NOT NULL", oConn);
            try
            {
                oConn.Open();
                OracleDataReader reader = genreListCommand.ExecuteReader();
                searchGenreDdId.DataSource = reader;
                searchGenreDdId.DataValueField = "Genre";
                searchGenreDdId.DataTextField = "Genre";
                searchGenreDdId.DataBind();
                searchGenreDdId.Items.Insert(0, new ListItem("All", "All"));

                reader = FriendsListCommand.ExecuteReader();
                searchFriendNameDdId.DataSource = reader;
                searchFriendNameDdId.DataValueField = "Name_Of_Friend";
                searchFriendNameDdId.DataTextField = "Name_Of_Friend";
                searchFriendNameDdId.DataBind();
                searchFriendNameDdId.Items.Insert(0, new ListItem("All", "All"));

            }
            finally
            {
                oConn.Close();
            }*/
        }
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

    protected void searchBtnId_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE Search:searchBtnId_Click*****");

        
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = null;

        if (searchGenreDdId.SelectedValue == "All" && searchFriendNameDdId.SelectedValue == "All")
        {
            oCmd = new OracleCommand("SELECT Name, Author, ISBN_Number, Genre, Name_Of_Friend " +
                                                    "FROM Books", oConn);

        }
        else if (searchGenreDdId.SelectedValue == "All" && searchFriendNameDdId.SelectedValue != null)
        {

            oCmd = new OracleCommand("SELECT Name, Author, ISBN_Number, Genre, Name_Of_Friend " +
                                                    "FROM Books " +
                                                    "WHERE Name_Of_Friend = '" + searchFriendNameDdId.SelectedValue + "' ", oConn);
        }
        else if (searchGenreDdId.SelectedValue != null && searchFriendNameDdId.SelectedValue == "All")
        {
            oCmd = new OracleCommand("SELECT Name, Author, ISBN_Number, Genre, Name_Of_Friend " +
                                                    "FROM Books " +
                                                    "WHERE Genre = '" + searchGenreDdId.SelectedValue + "'", oConn);
        }
        else
        {
            oCmd = new OracleCommand("SELECT Name, Author, ISBN_Number, Genre, Name_Of_Friend " +
                                                    "FROM Books " + 
                                                    "WHERE Genre = '" + searchGenreDdId.SelectedValue + "' AND Name_Of_Friend = '"+ searchFriendNameDdId.SelectedValue + "' ", oConn);
        }

        System.Diagnostics.Debug.WriteLine("*****INSIDE searchBtnId_Click:*****" + oCmd.CommandText);
        try
        {
            oConn.Open();            
            OracleDataReader reader = oCmd.ExecuteReader();
            searchedItemsGrid.DataSource = reader;
            searchedItemsGrid.DataKeyNames = new string[] { "Name" };
            searchedItemsGrid.DataBind();
            reader.Close();
        }
        finally
        {
            oConn.Close();
        }
    }

    protected void resetBtnId_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx");
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
