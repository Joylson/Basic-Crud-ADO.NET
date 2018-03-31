using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_ADO.NET
{
    public class Teste
    {
        private static UsuarioBLL _UsuarioBLL;
        public static void Main(string[] args)
        {
            _UsuarioBLL = new UsuarioBLL();

            while (true)
            {
                Console.WriteLine("\n Dados do banco");
                try
                {
                    foreach (var usuario in _UsuarioBLL.GetAll())
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.Write("Id: " + usuario.Id + " -- ");
                        Console.Write("Nome: " + usuario.Nome + " -- ");
                        Console.Write("Senha: " + usuario.Senha + " -- ");
                        Console.WriteLine("E-mail: " + usuario.Email);
                        Console.WriteLine("-----------------------------------------");
                    }
                }
                catch
                {
                    Console.WriteLine("Erro");
                }
                Console.WriteLine("Digite uma tecla");
                Console.WriteLine("\n G - Verificar um usuario \n I - Inserir um usuario \n U - Para altera um usuario \n D - para deletar");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.G:
                        Console.WriteLine("\n Digita o ID do objeto procurado");
                        var id = Console.ReadLine();
                        try
                        {
                            var usuario = _UsuarioBLL.Get(Convert.ToInt32(id));
                            Console.WriteLine("-----------------------------------------");
                            Console.Write("Id: " + usuario.Id + " -- ");
                            Console.Write("Nome: " + usuario.Nome + " -- ");
                            Console.Write("Senha: " + usuario.Senha + " -- ");
                            Console.WriteLine("E-mail: " + usuario.Email);
                            Console.WriteLine("-----------------------------------------");
                        }
                        catch
                        {
                            Console.WriteLine("Erro");
                        }
                         break;
                    case ConsoleKey.I:
                        Console.WriteLine("\n Dados a serem inseridos");
                        var usuarioI = new Usuario();
                        Console.WriteLine("Nome: ");
                        usuarioI.Nome = Console.ReadLine();
                        Console.WriteLine("Senha: ");
                        usuarioI.Senha = Console.ReadLine();
                        Console.WriteLine("Email: ");
                        usuarioI.Email = Console.ReadLine();
                        _UsuarioBLL.Insert(usuarioI);
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine("\n Dados a serem alterados");
                        var usuarioU = new Usuario();
                        Console.WriteLine("Id: ");
                        usuarioU.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nome: ");
                        usuarioU.Nome = Console.ReadLine();
                        Console.WriteLine("Senha: ");
                        usuarioU.Senha = Console.ReadLine();
                        Console.WriteLine("Email: ");
                        usuarioU.Email = Console.ReadLine();
                        _UsuarioBLL.Update(usuarioU);
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("\n ID do objeto a ser deletado");
                        var idD = Convert.ToInt32(Console.ReadLine());
                        _UsuarioBLL.Delete(idD);
                        break;
                }
                Console.WriteLine("Aperte S para sair ou outra tecla para continuar");
                if (Console.ReadKey().Key == ConsoleKey.S)
                    break;
            }
        }
    }
}
