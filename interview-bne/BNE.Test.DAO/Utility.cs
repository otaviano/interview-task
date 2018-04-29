using System.Configuration;
using System.Data.SqlClient;

namespace BNE.Test.DAO
{
  public class Utility
  {
    internal static string GetConnectionString()
    {
      string returnValue = null;

      var settings = ConfigurationManager.ConnectionStrings["connection"];

      if (settings != null)
        returnValue = settings.ConnectionString;

      return returnValue;
    }

    internal static SqlConnection GetConnection()
    {
      var connstr = GetConnectionString();
      return new SqlConnection(connstr);
    }
  }
}
