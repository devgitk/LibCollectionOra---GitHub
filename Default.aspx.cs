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
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {

        //Browser Details
        System.Web.HttpBrowserCapabilities browser = Request.Browser;

        //Read Cookie
        HttpCookie themeCookie;
        themeCookie = Request.Cookies["UserTheme" + browser.Browser];

        if(themeCookie == null)
        {
            System.Diagnostics.Debug.WriteLine("*****Creating Cookie*****");
            Session["ThemeSessionValue"] = "DarkTheme";// Default Theme is DarkTheme
            themeCookie = new HttpCookie(name: "UserTheme" + browser.Browser, value: "DarkTheme");
            themeCookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(themeCookie);
            Page.Theme = (string)Session["ThemeSessionValue"];  //REQUIRED to Set on STARTUP
        }
        else
        {
            Session["ThemeSessionValue"] = themeCookie.Value;   //Set in the Session Variable
            Page.Theme = (string)Session["ThemeSessionValue"];  //REQUIRED to Set on STARTUP
        }        
    }

    protected void CogLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Setup.aspx");
    }
}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
