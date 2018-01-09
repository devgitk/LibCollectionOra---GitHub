using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Xml;

public class AuditTrail
{

    internal static void Trail(string method, OracleParameterCollection parameters, string table, string ipAddress)
    {
        OracleConnection oConn = GetConnection();
        OracleCommand oCmd = oConn.CreateCommand();
        string insertString = "";

        if (method == "INSERT")
        {
            insertString = "INSERT INTO AUDIT_LOG (TEXT, CREATED_BY, IPADDRESS, METHOD, DESTINATION, CREATED_DATE) " +
                          "VALUES (:TEXT, :CREATED_BY, :IPADDRESS, :METHOD, :DESTINATION, SYSDATE)";
            oCmd.CommandText = insertString;

            oCmd.Parameters.Add(new OracleParameter("TEXT", ToXml(parameters)));
            oCmd.Parameters.Add(new OracleParameter("CREATED_BY", ipAddress));
            oCmd.Parameters.Add(new OracleParameter("IPADDRESS", ipAddress));
            oCmd.Parameters.Add(new OracleParameter("METHOD", method));
            oCmd.Parameters.Add(new OracleParameter("DESTINATION", table));

            System.Diagnostics.Debug.WriteLine(ToXml(parameters));
            System.Diagnostics.Debug.WriteLine(ipAddress);
        }
        else {

            insertString = "INSERT INTO AUDIT_LOG (TEXT, MODIFIED_BY, IPADDRESS, METHOD, DESTINATION, MODIFIED_DATE) " +
              "VALUES (:TEXT, :MODIFIED_BY, :IPADDRESS, :METHOD, :DESTINATION, SYSDATE)";
            oCmd.CommandText = insertString;

            oCmd.Parameters.Add(new OracleParameter("TEXT", ToXml(parameters)));
            oCmd.Parameters.Add(new OracleParameter("MODIFIED_BY", ipAddress));
            oCmd.Parameters.Add(new OracleParameter("IPADDRESS", ipAddress));
            oCmd.Parameters.Add(new OracleParameter("METHOD", method));
            oCmd.Parameters.Add(new OracleParameter("DESTINATION", table));

            System.Diagnostics.Debug.WriteLine(ToXml(parameters));
            System.Diagnostics.Debug.WriteLine(ipAddress);
        }
   
        try
        {
            oConn.Open();
            oCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("*****Exception***** " + ex.Message);
        }
        finally
        {
            oConn.Close();
        }
    }

    internal static OracleConnection GetConnection()
    {
        var conString = System.Configuration.ConfigurationManager.ConnectionStrings["LibCollectionOracleCenCol"];
        string strConnString = conString.ConnectionString;
        return new OracleConnection(strConnString);
    }

    internal static string ToXml(OracleParameterCollection parameters) {
        string xmlString = null;
        using (System.IO.StringWriter sw = new StringWriter())
        {
            System.Xml.XmlTextWriter writer = new XmlTextWriter(sw);
            writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
            writer.WriteStartElement("root"); 
            foreach (OracleParameter p in parameters)
            {
                writer.WriteStartElement("field");
                writer.WriteStartAttribute("col");
                writer.WriteString(p.ParameterName);
                writer.WriteEndAttribute();
                writer.WriteString(p.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            xmlString = sw.ToString();
        }
        return xmlString;
    }
}