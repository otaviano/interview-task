using System.Collections.Generic;

namespace BNE.Test.DAO.Interfaces
{
  public interface IDAO<T>
  {
    // Cadastro / Alteracao
    void Create(T entity);
    void Update(T entity);
    void Create(IList<T> entities);
    void Update(IList<T> entities);

    // Pesquisa
    T Get(int id);
    IList<T> All();
    
    void Delete(int id);
  }
}
