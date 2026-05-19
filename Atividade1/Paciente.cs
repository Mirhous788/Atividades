using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1
{
    public class Paciente : Pessoa
    {
        // preferencia: "alta", "media", "baixa"
        public string Preferencia { get; set; }

        // Método para cadastrar o paciente lendo dados do Console
        public bool Cadastrar(int id)
        {
            this.Id = id;

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido.");
                return false;
            }
            this.Nome = nome.Trim();

            Console.Write("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida.");
                return false;
            }
            this.Idade = idade;

            Console.Write("RG: ");
            string rg = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rg))
            {
                Console.WriteLine("RG inválido.");
                return false;
            }
            this.RG = rg.Trim();

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
                    Console.WriteLine("Opção de preferência inválida.");
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Idade: {Idade} | RG: {RG} | Preferência: {Preferencia}";
        }
    }
}
