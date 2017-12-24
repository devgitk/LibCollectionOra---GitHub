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
public partial class Setup : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {



        //Session["CookieValue"] = "Blank";
        System.Web.HttpBrowserCapabilities browser = Request.Browser;

        string s = "Browser Capabilities\n"
            + "Type = " + browser.Type + "\n"
            + "Name = " + browser.Browser + "\n"
            + "Version = " + browser.Version + "\n"
            + "Major Version = " + browser.MajorVersion + "\n"
            + "Minor Version = " + browser.MinorVersion + "\n"
            + "Platform = " + browser.Platform + "\n"
            + "Is Beta = " + browser.Beta + "\n"
            + "Is Crawler = " + browser.Crawler + "\n"
            + "Is AOL = " + browser.AOL + "\n"
            + "Is Win16 = " + browser.Win16 + "\n"
            + "Is Win32 = " + browser.Win32 + "\n"
            + "Supports Frames = " + browser.Frames + "\n"
            + "Supports Tables = " + browser.Tables + "\n"
            + "Supports Cookies = " + browser.Cookies + "\n"
            + "Supports VBScript = " + browser.VBScript + "\n"
            + "Supports JavaScript = " + browser.EcmaScriptVersion.ToString() + "\n"
            + "Supports Java Applets = " + browser.JavaApplets + "\n"
            + "Supports ActiveX Controls = " + browser.ActiveXControls + "\n"
            + "Supports JavaScript Version = " + browser["JavaScriptVersion"] + "\n";

        if(Session["ThemeSessionValue"] != null)
        {

            CookieText.Text = "The browser is "+ browser.Browser+" and the current theme is set to " +Session["ThemeSessionValue"].ToString();
        }

    }
    protected void lightTheme_Click(object sender, EventArgs e)
    {
        if (Session["ThemeSessionValue"] != null)
        {
            //Browser Details
            System.Web.HttpBrowserCapabilities browser = Request.Browser;

            Session["ThemeSessionValue"] = "LightTheme";    //Override existing value and Set in the Session

            //Write to Cookie UserTheme - second check
            HttpCookie themeCookie;
            themeCookie = Request.Cookies["UserTheme" + browser.Browser];
            if (themeCookie == null)
            {
                //Cookie does not exist           
                System.Diagnostics.Debug.WriteLine("*****Creating Cookie*****");
                Session["ThemeSessionValue"] = Session["ThemeSessionValue"].ToString();
                themeCookie = new HttpCookie(name: "UserTheme" + browser.Browser, value: Session["ThemeSessionValue"].ToString());
                themeCookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(themeCookie);
            }
            else
            {
                //Modify Cookie
                themeCookie.Value = Session["ThemeSessionValue"].ToString();
                themeCookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(themeCookie);
            }

            Response.Redirect("Default.aspx");
            Server.Transfer(Request.Path);
        }
    }
    protected void darkTheme_Click(object sender, EventArgs e)
    {
        if (Session["ThemeSessionValue"] != null)
        {
            //Browser Details
            System.Web.HttpBrowserCapabilities browser = Request.Browser;

            Session["ThemeSessionValue"] = "DarkTheme";    //Override existing value and Set in the Session

            //Write to Cookie UserTheme - second check
            HttpCookie themeCookie;
            themeCookie = Request.Cookies["UserTheme" + browser.Browser];
            if (themeCookie == null)
            {
                //Cookie does not exist           
                System.Diagnostics.Debug.WriteLine("*****Creating Cookie*****");
                Session["ThemeSessionValue"] = Session["ThemeSessionValue"].ToString();
                themeCookie = new HttpCookie(name: "UserTheme" + browser.Browser, value: Session["ThemeSessionValue"].ToString());
                themeCookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(themeCookie);
            }
            else
            {
                //Modify Cookie
                themeCookie.Value = Session["ThemeSessionValue"].ToString();
                themeCookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(themeCookie);
            }

            Response.Redirect("Default.aspx");
            Server.Transfer(Request.Path);
        }
    }

    protected void homeClick_Click(object sender, EventArgs e)
    {
        if (Session["ThemeSessionValue"] != null)
        {
            Session["ThemeSessionValue"] = Page.Theme;

            Response.Redirect("Default.aspx");
            Server.Transfer(Request.Path);
        }
     }

}
/*
 Name: Keshav Sridhara
 Student No: 300948195
 */
