using BNE.Test.DAO.Interfaces;

namespace BNE.Test.DAO
{
  internal class FactoryMSSQL : IFactoryDAO
  {
    public ITicketDAO GetTicketDAO() => new TicketMSSQL();
  }
}