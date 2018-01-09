using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
public partial class Search : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   
            OracleConnection oConn = GetConnection();
            OracleCommand genreListCommand = new OracleCommand("SELECT DISTINCT(NAME) FROM GENRE WHERE NAME IS NOT NULL", oConn);
            OracleCommand FriendsListCommand = new OracleCommand("SELECT DISTINCT(NAME) FROM FRIEND WHERE NAME IS NOT NULL", oConn);
            try
            {
                oConn.Open();
                OracleDataReader reader = genreListCommand.ExecuteReader();
                searchGenreDdId.DataSource = reader;
                searchGenreDdId.DataValueField = "Name";
                searchGenreDdId.DataTextField = "Name";
                searchGenreDdId.DataBind();
                searchGenreDdId.Items.Insert(0, new ListItem("All", "All"));

                reader = FriendsListCommand.ExecuteReader();
                searchFriendNameDdId.DataSource = reader;
                searchFriendNameDdId.DataValueField = "Name";
                searchFriendNameDdId.DataTextField = "Name";
                searchFriendNameDdId.DataBind();
                searchFriendNameDdId.Items.Insert(0, new ListItem("All", "All"));

            }
            finally
            {
                oConn.Close();
            }
        }
    }

    protected void searchBtnId_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("*****INSIDE Search:searchBtnId_Click*****");

        
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = null;

        if (searchGenreDdId.SelectedValue == "All" && searchFriendNameDdId.SelectedValue == "All")
        {
            oCmd = new OracleCommand("SELECT b.name BOOKNAME, f.name FRIENDNAME, rent_status, g.name Genre, r.rent_id  " +
                                     "FROM rent r, rent_details rd, books b, friend f, genre g  " +
                                     "WHERE r.rent_id = rd.rent_id " +
                                     "AND b.book_id = rd.rent_id " +
                                     "AND f.friend_id = r.friend_id " +
                                     "AND g.genre_id = b.genre_id", oConn);

        }
        else if (searchGenreDdId.SelectedValue == "All" && searchFriendNameDdId.SelectedValue != null)
        {

            oCmd = new OracleCommand("SELECT b.name BOOKNAME, f.name FRIENDNAME, rent_status, g.name Genre, r.rent_id  " +
                                    "FROM rent r, rent_details rd, books b, friend f, genre g  " +
                                    "WHERE r.rent_id = rd.rent_id " +
                                    "AND b.book_id = rd.rent_id " +
                                    "AND f.friend_id = r.friend_id " +
                                    "AND g.genre_id = b.genre_id " +
                                    "AND f.name = '" + searchFriendNameDdId.SelectedValue + "' ", oConn);
        }
        else if (searchGenreDdId.SelectedValue != null && searchFriendNameDdId.SelectedValue == "All")
        {
            oCmd = new OracleCommand("SELECT b.name BOOKNAME, f.name FRIENDNAME, rent_status, g.name Genre, r.rent_id  " +
                                    "FROM rent r, rent_details rd, books b, genre g, friend f " +
                                    "WHERE r.rent_id = rd.rent_id " +
                                    "AND b.book_id = rd.rent_id " +
                                    "AND f.friend_id = r.friend_id " +
                                    "AND g.genre_id = b.genre_id " +
                                    "AND g.name = '" + searchGenreDdId.SelectedValue + "'", oConn);
        }
        else
        {
            oCmd = new OracleCommand("SELECT b.name BOOKNAME, f.name FRIENDNAME, rent_status, g.name Genre, r.rent_id  " +
                                    "FROM rent r, rent_details rd, books b, friend f, genre g  " +
                                    "WHERE r.rent_id = rd.rent_id " +
                                    "AND b.book_id = rd.rent_id " +
                                    "AND f.friend_id = r.friend_id " +
                                    "AND g.genre_id = b.genre_id " +
                                    "AND g.name = '" + searchGenreDdId.SelectedValue + "' " +
                                    "AND f.name = '" + searchFriendNameDdId.SelectedValue + "' ", oConn);
        }

        System.Diagnostics.Debug.WriteLine("*****INSIDE searchBtnId_Click:*****" + oCmd.CommandText);
        try
        {
            oConn.Open();            
            OracleDataReader reader = oCmd.ExecuteReader();
            searchedItemsGrid.DataSource = reader;
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
