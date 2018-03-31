using DAL.Factory;
using System.Collections.Generic;
using System.Data;
using DTO;

namespace DAL
{
    public class UsuarioDAL:IUsuarioDAL<Usuario>
    {
        private Connection _Conn;

        public UsuarioDAL()
        {
            _Conn = new Connection();
        }

        public void Delete(int id)
        {
            _Conn.OpenConnection();
            _Conn.InsertCommand($"DELETE FROM Usuario WHERE Id = {id};",CommandType.Text);
            _Conn.ExculteNonQuery();
            _Conn.CloseConnection();
        }

        public Usuario Get(int id)
        {
            _Conn.OpenConnection();
            _Conn.InsertCommand($"SELECT * FROM Usuario WHERE Id = {id};",CommandType.Text);
            var usuario = new Usuario();
            using (var read = _Conn.ExeculteReader())
            {
                if (read.Read())
                {
                    usuario.Id = read.GetInt32(read.GetOrdinal("Id"));
                    usuario.Nome = read.GetString(read.GetOrdinal("Nome"));
                    usuario.Senha = read.GetString(read.GetOrdinal("Senha"));
                    usuario.Email = read.GetString(read.GetOrdinal("Email"));
                }
                else
                {
                    usuario = null;
                }
            }
            _Conn.CloseConnection();
            return usuario;
        }

        public IEnumerable<Usuario> GetAll()
        {
            _Conn.OpenConnection();
            _Conn.InsertCommand("SELECT * FROM Usuario", CommandType.Text);
            var usuarios = new List<Usuario>();
            using (var read = _Conn.ExeculteReader())
            {
                while (read.Read())
                {
                    usuarios.Add(new Usuario() {
                        Id = read.GetInt32(read.GetOrdinal("Id")),
                        Nome = read.GetString(read.GetOrdinal("Nome")),
                        Senha = read.GetString(read.GetOrdinal("Senha")),
                        Email = read.GetString(read.GetOrdinal("Email"))
                    });
                }
            }
            _Conn.CloseConnection();
            return usuarios;
        }

        public void Insert(Usuario entity)
        {
            _Conn.OpenConnection();
            _Conn.InsertCommand(
                $"INSERT INTO Usuario(Nome,Senha,Email) VALUES('{entity.Nome}', '{entity.Senha}', '{entity.Email}');",
                CommandType.Text
                );
            _Conn.ExculteNonQuery();
            _Conn.CloseConnection();
        }

        public void Update(Usuario entity)
        {
            _Conn.OpenConnection();
            _Conn.InsertCommand($"UPADATE Usuario SET Nome = '{entity.Nome}', Senha = '{entity.Senha}', Email = '{entity.Email}' WHERE Id = {entity.Id};", CommandType.Text);
            _Conn.CloseConnection();
        }
    }
}
