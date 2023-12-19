                                        using System.ComponentModel;
                                        using System.Data;
                                        using Microsoft.Win32.SafeHandles;

                                        namespace DesafioFundamentos.Models
                                        {
                                            /// <summary>
                                            /// Classe responsável pela atribuição de valores aos preços e lista iniciais.
                                            /// </summary>
                                            public class Estacionamento
                                            {
                                                private decimal precoInicial = 0;
                                                private decimal precoPorHora = 0;
                                                private List<string> veiculos = new List<string>();
                                                /// <summary>
                                                /// Construtor que atribui valores aos preços iniciais.
                                                /// </summary>
                                                /// <param name="precoInicial"></param>
                                                /// <param name="precoPorHora"></param>
                                                public Estacionamento(decimal precoInicial, decimal precoPorHora)
                                                {
                                                    this.precoInicial = precoInicial;
                                                    this.precoPorHora = precoPorHora;
                                                }
                                                    /// <summary>
                                                    /// Método responsável pela adição de veículos em sua lista respectiva.
                                                    /// </summary>
                                                public void AdicionarVeiculo()
                                                {
                                                    Console.WriteLine("Digite a placa do veículo para estacionar: ");
                                                    string placa = Console.ReadLine();
                                                    // Uma validação de placa é feita para, então, adicionar a placa em uma lista.
                                                    while (!ValidarPlaca(placa))
                                                    {
                                                    Console.WriteLine($"{placa} - Erro, placa inválida. Digite novamente: ");
                                                    placa = Console.ReadLine();
                                                    }            
                                                    veiculos.Add(placa);
                                                }
                                                /// <summary>
                                                /// Método de validação simples de uma placa de acordo com os padrão brasileiro.
                                                /// </summary>
                                                /// <param name="placa"></param>
                                                /// <returns></returns>
                                                private static bool ValidarPlaca(string placa)
                                                {
                                                    if (placa.Length != 7 )
                                                    return false;

                                                    int placaNumeros = 0;
                                                    int placaLetras = 0;
                                                    foreach (var item in placa.ToArray())
                                                    {
                                                        if (Char.IsDigit(item))
                                                        placaNumeros ++;
                                                        else 
                                                        placaLetras ++;
                                                    }
                                                    if (placaNumeros != 3 && placaLetras != 4)
                                                    return false;

                                                    return true;
                                                }
                                                /// <summary>
                                                /// Método de remoção de um veículo.
                                                /// </summary>
                                                public void RemoverVeiculo()
                                                {
                                                    Console.WriteLine("Digite a placa do veículo para remover:");

                                                    // Validação da placa em sua escrita correta e existência.
                                                    string placa = Console.ReadLine();
                                                    while(!veiculos.Any(x => x.ToUpper() == placa) && !ValidarPlaca(placa))
                                                    {
                                                        Console.WriteLine($"{placa} - Erro, placa inválida ou de um veículo não estacionado. Digite novamente: ");
                                                        placa = Console.ReadLine();
                                                    }
                                                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                                                    string horasString = Console.ReadLine();                     

                                                    veiculos.Remove(placa);
                                                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ " + ValorTotal(Convert.ToInt32(horasString)));
                                                }
                                                /// <summary>
                                                /// Método privado responsável pela equação do valor total do estacionamento.
                                                /// </summary>
                                                /// <param name="horas"></param>
                                                /// <returns></returns>
                                                private decimal ValorTotal(int horas)
                                                {
                                                    return precoInicial + precoPorHora * horas;
                                                }
                                                /// <summary>
                                                /// Método responsável pela amostra dos itens na lista de veículos.
                                                /// </summary>
                                                public void ListarVeiculos()
                                                {
                                                    // Verifica se há veículos no estacionamento.
                                                    if (veiculos.Any())
                                                    {
                                                        Console.WriteLine("Os veículos estacionados são:");
                                                        foreach (string item in veiculos)
                                                        {
                                                            Console.WriteLine(item);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Não há veículos estacionados.");
                                                    }
                                                }
                                            }
                                        }
