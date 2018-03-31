using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL: IUsuarioBLL<Usuario>
    {
        private UsuarioDAL _UsuarioDAL;

        public UsuarioBLL()
        {
            _UsuarioDAL = new UsuarioDAL();
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var usuarios = _UsuarioDAL.GetAll();
                if (usuarios == null)
                    throw new ArgumentNullException("Nenhum usuario encontrado");
                return usuarios;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Pseudo Log: Function = GetALL Erro = " + ex.Message);
                throw;
            }
        }

        public Usuario Get(int id)
        {
            try
            {
                var usuario = _UsuarioDAL.Get(id);
                if (usuario == null)
                    throw new ArgumentNullException("Usuario não encontrado");
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pseudo Log: Function = Get Erro = " + ex.Message);
                throw;
            }
        }

        public void Insert(Usuario entity)
        {
            try
            {
                _UsuarioDAL.Insert(entity);
                Console.WriteLine("CONCLUIDO");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pseudo Log: Function = Insert Erro = " + ex.Message);
                throw;
            }
        }

        public void Update(Usuario entity)
        {
            try
            {
                _UsuarioDAL.Update(entity);
                Console.WriteLine("CONCLUIDO");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pseudo Log: Function = Update Erro = " + ex.Message);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _UsuarioDAL.Delete(id);
                Console.WriteLine("CONCLUIDO");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pseudo Log: Function = Delete Erro = " + ex.Message);
                throw;
            }
        }
    }
}
