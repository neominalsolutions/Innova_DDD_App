using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.Infra.Core
{

  // Birden fazla repository tek bir transaction altında yönetmek için kullanacağımız bir arayüz, port
  public interface IUnitOfWork
  {
    void Commit();
  }
}
