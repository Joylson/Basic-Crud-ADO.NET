using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IUsuarioDAL<entity> where entity: class
    {
        IEnumerable<entity> GetAll();
        entity Get(int id);
        void Insert(entity entity);
        void Update(entity entity);
        void Delete(int id);
    }
}
