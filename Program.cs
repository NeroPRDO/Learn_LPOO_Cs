using System;
using System.Collections.Generic;

namespace SistemaBancario
{
    // Classe que representa uma Conta Bancária
    public class ContaBancaria
    {
        private string titular;
        private int numeroConta;
        private double saldo;

        // Propriedade pública para ler o número da conta
        public int NumeroConta
        {
            get { return numeroConta; }
        }

        public ContaBancaria(string titular, int numeroConta)
        {
            this.titular = titular;
            this.numeroConta = numeroConta;
            this.saldo = 0.0;
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Console.WriteLine($"Depósito de R${valor} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valor inválido para depósito.");
            }
        }

        public void Sacar(double valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de R${valor} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque.");
            }
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"Número da Conta: {numeroConta}");
            Console.WriteLine($"Saldo: R${saldo:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ContaBancaria> contas = new List<ContaBancaria>();

            while (true)
            {
                Console.WriteLine("\n=== MENU DO BANCO ===");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Ver Saldo");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do titular: ");
                        string? nome = Console.ReadLine();

                        Console.Write("Número da conta: ");
                        if (int.TryParse(Console.ReadLine(), out int numeroNovaConta))
                        {
                            contas.Add(new ContaBancaria(nome ?? "Desconhecido", numeroNovaConta));
                            Console.WriteLine("Conta criada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Número da conta inválido.");
                        }
                        break;

                    case "2":
                        Console.Write("Número da conta: ");
                        if (int.TryParse(Console.ReadLine(), out int numDeposito))
                        {
                            ContaBancaria? contaDeposito = contas.Find(c => c.NumeroConta == numDeposito);
                            if (contaDeposito != null)
                            {
                                Console.Write("Valor do depósito: ");
                                if (double.TryParse(Console.ReadLine(), out double valorDep))
                                {
                                    contaDeposito.Depositar(valorDep);
                                }
                                else
                                {
                                    Console.WriteLine("Valor inválido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Conta não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número da conta inválido.");
                        }
                        break;

                    case "3":
                        Console.Write("Número da conta: ");
                        if (int.TryParse(Console.ReadLine(), out int numSaque))
                        {
                            ContaBancaria? contaSaque = contas.Find(c => c.NumeroConta == numSaque);
                            if (contaSaque != null)
                            {
                                Console.Write("Valor do saque: ");
                                if (double.TryParse(Console.ReadLine(), out double valorSaque))
                                {
                                    contaSaque.Sacar(valorSaque);
                                }
                                else
                                {
                                    Console.WriteLine("Valor inválido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Conta não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número da conta inválido.");
                        }
                        break;

                    case "4":
                        Console.Write("Número da conta: ");
                        if (int.TryParse(Console.ReadLine(), out int numInfo))
                        {
                            ContaBancaria? contaInfo = contas.Find(c => c.NumeroConta == numInfo);
                            if (contaInfo != null)
                            {
                                contaInfo.ExibirInformacoes();
                            }
                            else
                            {
                                Console.WriteLine("Conta não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Número da conta inválido.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Encerrando o programa...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
