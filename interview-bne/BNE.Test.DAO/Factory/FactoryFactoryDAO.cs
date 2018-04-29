using BNE.Test.DAO.Interfaces;
using System;
using System.Configuration;

namespace BNE.Test.DAO.Factory
{

  public static class FactoryFactoryDAO
  {
    public static IFactoryDAO GetFactory()
    {
      if (string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("Provider")))
        throw new ArgumentNullException("Provider", "Provider não configurado no arquivo de configuração.");

      var provider = (Provider)Enum.Parse(typeof(Provider), ConfigurationManager.AppSettings.Get("Provider"));

      switch (provider)
      {
        case Provider.MSSQL:
          return new FactoryMSSQL();
        case Provider.Odbc:
        case Provider.OleDB:
        case Provider.Oracle:
        case Provider.Postgre:
        case Provider.Sybase:
          throw new NotImplementedException("Provider não implementado");
        default:
          throw new ArgumentNullException("Provider", "Provider não implementado");
      }
    }
  }
}


