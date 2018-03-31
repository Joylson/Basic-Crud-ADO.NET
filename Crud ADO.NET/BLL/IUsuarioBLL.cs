using System.Collections.Generic;

namespace BLL
{
    interface IUsuarioBLL<entity> where entity: class
    {
        IEnumerable<entity> GetAll();
        entity Get(int id);
        void Insert(entity entity);
        void Update(entity entity);
        void Delete(int id);
    }
}
