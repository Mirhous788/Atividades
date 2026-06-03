using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1
{
    class Program
    {
        static void Main(string[] args)
        {
            Paciente[] fila = new Paciente[10];
            int cont = 0;
            Paciente paciente = new Paciente();

            MostrarMenu();
            Console.Write("Escolha uma opção: ");
            string opc = Console.ReadLine();

            switch (opc)
            { 
                case "1": 
                    this.paciente.Cadastrar(); 
                    break;
                case "2": 
                    ListarPacientes(); 
                    break;
                case "q" || "Q":
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            Console.WriteLine();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("--- Sistema de Fila de Pacientes ---");
            Console.WriteLine("1 - Cadastrar paciente na fila");
            Console.WriteLine("2 - Listar pacientes da fila");
            Console.WriteLine("q - Sair");
        }

        static void ListarPacientes()
        {
            Console.WriteLine("--- Lista de Pacientes na Fila ---");
            if (this.count == 0)
            {
                Console.WriteLine("Fila vazia."); 
                return;
            }
            for (int i = 0; i < this.count; i++)
            {
                Console.WriteLine($"Posição {i + 1}: {this.fila[i]}");
            }
        }
    }
}
