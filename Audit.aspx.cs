using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Audit : BasePage
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
        OracleCommand oCmd = new OracleCommand("SELECT a.*,AUDIT_LOG_DATE_FUNC(a.METHOD,a.CREATED_DATE,a.MODIFIED_DATE) R_DATE FROM AUDIT_LOG a ORDER BY AUDIT_LOG_ID DESC", oConn);
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
        }
        finally
        {
            oConn.Close();
        }
    }

    protected void grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDetailsView(grid.SelectedValue.ToString());
    }

    private void BindDetailsView(string value)
    {
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = new OracleCommand("SELECT * FROM AUDIT_LOG WHERE AUDIT_LOG_ID = :AUDIT_LOG_ID", oConn);
        oCmd.Parameters.Add(new OracleParameter("AUDIT_LOG_ID", value));

        try
        {
            oConn.Open();
            OracleDataReader reader = oCmd.ExecuteReader();
            if (reader.FetchSize > 0)
            {
                gridDetail.DataSource = reader;
                gridDetail.DataBind();
                reader.Close();
            }
        }
        finally
        {
            oConn.Close();
        }
    }
}