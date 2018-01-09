using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        this.PreInit += new EventHandler(BasePage_PreInit);
    }

    private void BasePage_PreInit(object sender, EventArgs e)
    {
        //Browser Details
        System.Web.HttpBrowserCapabilities browser = Request.Browser;

        //Read Cookie
        HttpCookie themeCookie;
        themeCookie = Request.Cookies["UserTheme" + browser.Browser];

        if (themeCookie == null)
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

    protected OracleConnection GetConnection()
    {
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["LibCollectionOracleCenCol"];
        string strConnString = conString.ConnectionString;
        return new OracleConnection(strConnString);
    }

    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }

    protected void CreateAuditInsertRecord(OracleParameterCollection parameters, string table) {
        AuditTrail.Trail("INSERT", parameters, table, GetIPAddress());
    }
    protected void CreateAuditUpdateRecord(OracleParameterCollection parameters, string table)
    {
        AuditTrail.Trail("UPDATE", parameters, table, GetIPAddress());
    }
    protected void CreateAuditDeleteRecord(OracleParameterCollection parameters, string table)
    {
        AuditTrail.Trail("DELETE", parameters, table, GetIPAddress());
    }
}