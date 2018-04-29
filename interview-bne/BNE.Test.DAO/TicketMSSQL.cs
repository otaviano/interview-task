using BNE.Test.DAO.Interfaces;
using BNE.Test.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNE.Test.DAO
{
  class TicketMSSQL : ITicketDAO
  {
    #region query

    const string queryGet = @"SELECT * FROM ticket WHERE id = @id";

    const string queryGetAll = @"SELECT * FROM ticket ORDER BY date DESC";

    const string queryInsert = @"INSERT INTO ticket 
                                OUTPUT INSERTED.ID
                                VALUES (@first_number, @second_number, @third_number, @forth_number, @fifth_number, @sixth_number, @date)";

    const string queryUpdate = @"UPDATE ticket SET
                                  first_number = @first_number, 
                                  second_number = @second_number,
                                  third_number = @third_number, 
                                  forth_number = @forth_number,
                                  fifth_number = @fifth_number, 
                                  sixth_number = @sixth_number
                                WHERE id = @id";

    const string queryDelete = @"SELECT * FROM ticket";

    #endregion

    public TicketMSSQL()
    {
    }

    public void Create(Ticket entity)
    {
      using (var conn = Utility.GetConnection())
      {
        try
        {
          var command = new SqlCommand(queryInsert, conn);

          command.Parameters.AddWithValue("@first_number", entity.FirstNumber);
          command.Parameters.AddWithValue("@second_number", entity.SecondNumber);
          command.Parameters.AddWithValue("@third_number", entity.ThirdNumber);
          command.Parameters.AddWithValue("@forth_number", entity.ForthNumber);
          command.Parameters.AddWithValue("@fifth_number", entity.FifthNumber);
          command.Parameters.AddWithValue("@sixth_number", entity.SixthNumber);
          command.Parameters.AddWithValue("@date", DateTime.Now);
          
          conn.Open();
          entity.Id = Convert.ToInt32(command.ExecuteScalar());
        }
        catch (SqlException ex)
        {
          throw new ApplicationException("Erro ao salvar", ex);
        }
      }
    }

    public void Create(IList<Ticket> entities)
    {
      entities.ToList().ForEach(p => Create(p));
    }

    public void Delete(int id)
    {
      using (var conn = Utility.GetConnection())
      {
        try
        {
          var command = new SqlCommand(queryDelete, conn);

          command.Parameters.AddWithValue("@id", id);

          conn.Open();
          command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          throw new ApplicationException("Erro ao excluir", ex);
        }
      }

    }

    public Ticket Get(int id)
    {
      using (var conn = Utility.GetConnection())
      {
        try
        {
          var command = new SqlCommand(queryGet, conn);
          command.Parameters.AddWithValue("@id", id);

          conn.Open();

          SqlDataReader reader = command.ExecuteReader();
          Ticket obj = null; 

          if (reader.Read())
          {
            obj = new Ticket
            {
              Id = Convert.ToInt32(reader["id"]),
              FirstNumber  = Convert.ToInt32(reader["first_number"]),
              SecondNumber = Convert.ToInt32(reader["SecondNumbers"]),
              ThirdNumber  = Convert.ToInt32(reader["Third_number"]),
              ForthNumber  = Convert.ToInt32(reader["Forth_number"]),
              FifthNumber  = Convert.ToInt32(reader["Fifth_number"]),
              SixthNumber  = Convert.ToInt32(reader["Sixth_number"]),
              Date = Convert.ToDateTime(reader["date"]),
            };
          }

          reader.Close();
          return obj;
        }
        catch (SqlException ex)
        {
          throw new ApplicationException("Erro Ao realizar consulta", ex);
        }
      }
    }

    public IList<Ticket> All()
    {
      using (var conn = Utility.GetConnection())
      {
        var command = new SqlCommand(queryGetAll, conn);

        try
        {
          conn.Open();
          SqlDataReader reader = command.ExecuteReader();
          IList<Ticket> list = new List<Ticket>();

          while (reader.Read())
          {
            list.Add(new Ticket
            {
              Id = Convert.ToInt32(reader["id"]),
              FirstNumber = Convert.ToInt32(reader["first_number"]),
              SecondNumber = Convert.ToInt32(reader["Second_Number"]),
              ThirdNumber = Convert.ToInt32(reader["Third_number"]),
              ForthNumber = Convert.ToInt32(reader["Forth_number"]),
              FifthNumber = Convert.ToInt32(reader["Fifth_number"]),
              SixthNumber = Convert.ToInt32(reader["Sixth_number"]),
              Date = Convert.ToDateTime(reader["date"]),
            });
          }

          reader.Close();
          return list;
        }
        catch (SqlException ex)
        {
          throw new ApplicationException("Erro Ao realizar consulta", ex);
        }
      }
    }

    public void Update(Ticket entity)
    {
      using (var conn = Utility.GetConnection())
      {
        try
        {
          var command = new SqlCommand(queryUpdate, conn);

          command.Parameters.AddWithValue("@id", entity.Id);
          command.Parameters.AddWithValue("@first_number", entity.FirstNumber);
          command.Parameters.AddWithValue("@second_number", entity.SecondNumber);
          command.Parameters.AddWithValue("@third_number", entity.ThirdNumber);
          command.Parameters.AddWithValue("@forth_number", entity.ForthNumber);
          command.Parameters.AddWithValue("@fifth_number", entity.FifthNumber);
          command.Parameters.AddWithValue("@sixth_number", entity.SixthNumber);

          conn.Open();
          command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
          throw new ApplicationException("Erro ao salvar", ex);
        }
      }
    }

    public void Update(IList<Ticket> entities)
    {
      entities.ToList().ForEach(p => Update(p));
    }
  }
}

