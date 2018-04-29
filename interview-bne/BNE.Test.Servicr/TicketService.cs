using BNE.Test.Domain;
using BNE.Test.DAO.Factory;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BNE.Test.Service
{
  public class TicketService
  {
    public void SaveGame(Ticket ticket)
    {
      var repository = FactoryFactoryDAO.GetFactory().GetTicketDAO();

      ValidateTicket(ticket);

      if (ticket.Id <= 0)
        repository.Create(ticket);
      else
        repository.Update(ticket);
    }

    public IList<Ticket> GetLastGames()
    {
      var repository = FactoryFactoryDAO.GetFactory().GetTicketDAO();

      return repository.All().Take(10).ToList();
    }

    private void ValidateTicket(Ticket ticket)
    {
      if (!ValidateRange(ticket.FirstNumber)
        || !ValidateRange(ticket.SecondNumber)
        || !ValidateRange(ticket.ThirdNumber)
        || !ValidateRange(ticket.ForthNumber)
        || !ValidateRange(ticket.FifthNumber)
        || !ValidateRange(ticket.SixthNumber))
        throw new ArgumentOutOfRangeException("number", "Todos os números devem ser entre 1 e 60");
    }

    private bool ValidateRange(int number)
    {
      if (Enumerable.Range(1, 60).Contains(number))
        return true;

      return false;
    }
  }
}
