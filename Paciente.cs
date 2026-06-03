using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1
{
    public class Paciente : Pessoa
    {
        public string Preferencia;

        public void Cadastrar()
        {
            this.Id = this.cont;

            Console.Write("Nome: ");
            this.Nome = Console.ReadLine();

            Console.Write("Idade: ");
            this.Idade = int.Parse(Console.ReadLine());

            Console.Write("RG: ");
            this.RG = Console.ReadLine();

            Console.WriteLine("Escolha a preferência:");
            Console.WriteLine("1 - alta");
            Console.WriteLine("2 - media");
            Console.WriteLine("3 - baixa");
            Console.Write("Opção: ");
            string op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    this.Preferencia = "alta";
                    break;
                case "2":
                    this.Preferencia = "media";
                    break;
                case "3":
                    this.Preferencia = "baixa";
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            this.cont = this.cont + 1;
        }
    }
}
