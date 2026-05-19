using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1
{
    class Program
    {
        static Paciente[] fila = new Paciente[100];
        static int count = 0;
        static int nextId = 1;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                MostrarMenu();
                Console.Write("Escolha uma opção: ");
                string opc = Console.ReadLine();
                if (string.IsNullOrEmpty(opc)) continue;
                if (opc.Trim().ToLower() == "q") break;

                switch (opc)
                {
                    case "1": CadastrarPaciente(); break;
                    case "2": ListarPacientes(); break;
                    case "3": AtenderPaciente(); break;
                    case "4": AlterarPaciente(); break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("--- Sistema de Fila de Pacientes ---");
            Console.WriteLine("1 - Cadastrar paciente na fila");
            Console.WriteLine("2 - Listar pacientes da fila");
            Console.WriteLine("3 - Atender paciente (remover da fila)");
            Console.WriteLine("4 - Alterar dados cadastrais do paciente");
            Console.WriteLine("q - Sair");
        }

        static void CadastrarPaciente()
        {
            if (count >= fila.Length)
            {
                Console.WriteLine("Fila cheia. Não é possível cadastrar mais pacientes.");
                return;
            }
            var p = new Paciente();
            if (!p.Cadastrar(nextId)) return;
            nextId++;

            // Inserir no vetor respeitando preferência (alta > media > baixa)
            int newPrio = Prioridade(p.Preferencia);
            int insertIndex = count; // por padrão no fim
            for (int i = 0; i < count; i++)
            {
                int existingPrio = Prioridade(fila[i].Preferencia);
                if (existingPrio < newPrio)
                {
                    insertIndex = i;
                    break;
                }
            }

            // deslocar para a direita
            for (int j = count; j > insertIndex; j--)
            {
                fila[j] = fila[j - 1];
            }
            fila[insertIndex] = p;
            count++;
            Console.WriteLine("Paciente cadastrado e inserido na fila.");
        }

        static void ListarPacientes()
        {
            Console.WriteLine("--- Lista de Pacientes na Fila ---");
            if (count == 0)
            {
                Console.WriteLine("Fila vazia.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Posição {i + 1}: {fila[i]}");
            }
        }

        static void AtenderPaciente()
        {
            if (count == 0)
            {
                Console.WriteLine("Fila vazia. Nenhum paciente para atender.");
                return;
            }
            var atendido = fila[0];
            // deslocar para a esquerda
            for (int i = 1; i < count; i++)
            {
                fila[i - 1] = fila[i];
            }
            fila[count - 1] = null;
            count--;
            Console.WriteLine("Paciente atendido:");
            Console.WriteLine(atendido);
        }

        static void AlterarPaciente()
        {
            if (count == 0)
            {
                Console.WriteLine("Fila vazia.");
                return;
            }

            Console.Write("Digite o ID do paciente a alterar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            int idx = -1;
            for (int i = 0; i < count; i++) if (fila[i].Id == id) { idx = i; break; }
            if (idx == -1)
            {
                Console.WriteLine("Paciente não encontrado.");
                return;
            }

            var paciente = fila[idx];
            Console.WriteLine("Dados atuais: " + paciente);
            Console.Write("Novo nome (enter para manter): ");
            string nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome)) paciente.Nome = nome.Trim();

            Console.Write("Nova idade (enter para manter): ");
            string idadeStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(idadeStr) && int.TryParse(idadeStr, out int novaIdade))
                paciente.Idade = novaIdade;

            Console.WriteLine("Alterar preferência?");
            string pref = LerPreferencia(allowSkip: true);
            if (pref != null) paciente.Preferencia = pref;

            // Remover da posição atual
            for (int i = idx + 1; i < count; i++) fila[i - 1] = fila[i];
            fila[count - 1] = null;
            count--;

            // Reinserir respeitando nova preferência mantendo o mesmo objeto
            int newPrio = Prioridade(paciente.Preferencia);
            int insertIndex = count;
            for (int i = 0; i < count; i++)
            {
                int existingPrio = Prioridade(fila[i].Preferencia);
                if (existingPrio < newPrio)
                {
                    insertIndex = i;
                    break;
                }
            }
            for (int j = count; j > insertIndex; j--) fila[j] = fila[j - 1];
            fila[insertIndex] = paciente;
            count++;

            Console.WriteLine("Dados do paciente atualizados.");
        }

        static string LerPreferencia(bool allowSkip = false)
        {
            Console.WriteLine("Escolha a preferência:");
            Console.WriteLine("1 - alta");
            Console.WriteLine("2 - media");
            Console.WriteLine("3 - baixa");
            if (allowSkip) Console.WriteLine("Enter para manter a atual");
            Console.Write("Opção: ");
            string op = Console.ReadLine();
            if (allowSkip && string.IsNullOrWhiteSpace(op)) return null;
            switch (op)
            {
                case "1": return "alta";
                case "2": return "media";
                case "3": return "baixa";
                default:
                    Console.WriteLine("Opção de preferência inválida.");
                    return null;
            }
        }

        static int Prioridade(string pref)
        {
            switch (pref?.ToLower())
            {
                case "alta": return 3;
                case "media": return 2;
                case "baixa": return 1;
                default: return 0;
            }
        }
    }
}
