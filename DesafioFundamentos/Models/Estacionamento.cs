namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private List<Veiculo> listaCarros = new List<Veiculo>();
        private List<Veiculo> listaMotos = new List<Veiculo>();
        private int vagasCarro = 35;
        private int vagasMoto = 50;
        private int vagasCarroPcd = 5;
        private int vagasCarroIdosos = 5;
        private int vagasCarroGestantes = 5;

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Qual veículo deseja estacionar?\n[1] Carro \n[2] Moto");
            int tipoVeiculo = Convert.ToInt32(Console.ReadLine());

            if (tipoVeiculo == 1) 
            {
                Console.WriteLine("Digite a placa do carro para estacionar:");
                string placa = Console.ReadLine();

                Console.WriteLine("Necessita de acessibilidade?\n[1] Sim\n[2] Não");
                int necessitaAcessibilidade = Convert.ToInt32(Console.ReadLine());

                if (necessitaAcessibilidade == 1)
                {
                    Console.WriteLine("Selecione o tipo de acessibilidade:\n" +
                                        "1 - PCD\n" +
                                        "2 - Idosos\n" +
                                        "3 - Gestantes");

                    int tipoAcessibilidade = Convert.ToInt32(Console.ReadLine());

                    if (tipoAcessibilidade == 1)
                    {
                        if (vagasCarroPcd > 0) 
                        {
                            listaCarros.Add(new Carro(placa));
                            Console.WriteLine($"Carro de placa {placa} estacionado em vaga reservada para PCD.");
                            vagasCarroPcd--;
                        } 
                        else 
                        {
                            if (vagasCarro > 0) 
                            {
                                listaCarros.Add(new Carro(placa));
                                Console.WriteLine($"Todas as vagas reservadas estão ocupadas. Carro de placa {placa} estacionado em vaga comum.");
                                vagasCarro--;
                            } 
                            else 
                            {
                                Console.WriteLine("Desculpe, não há vagas disponíveis.");
                            }
                        }
                    } 
                    else if (tipoAcessibilidade == 2) 
                    {
                        if (vagasCarroIdosos > 0) 
                        {
                            listaCarros.Add(new Carro(placa));
                            Console.WriteLine($"Carro de placa {placa} estacionado em vaga reservada para Idosos.");
                            vagasCarroIdosos--;
                        } 
                        else 
                        {
                            if (vagasCarro > 0) 
                            {
                                listaCarros.Add(new Carro(placa));
                                Console.WriteLine($"Todas as vagas reservadas para Idosos estão ocupadas. Carro de placa {placa} estacionado em vaga comum.");
                                vagasCarro--;
                            }
                            else 
                            {
                                Console.WriteLine("Desculpe, não há vagas disponíveis.");
                            }
                        }
                    } 
                    else if (tipoAcessibilidade == 3) 
                    {
                        if (vagasCarroGestantes > 0) 
                        {
                            listaCarros.Add(new Carro(placa));
                            Console.WriteLine($"Carro de placa {placa} estacionado em vaga reservada para Gestantes.");
                            vagasCarroGestantes--;
                        } 
                        else 
                        {
                            if (vagasCarro > 0) 
                            {
                                listaCarros.Add(new Carro(placa));
                                Console.WriteLine($"Todas as vagas reservadas para Gestantes estão ocupadas. Carro de placa {placa} estacionado em vaga comum.");
                                vagasCarro--;
                            } 
                            else 
                            {
                                Console.WriteLine("Desculpe, não há vagas disponíveis.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente!");
                    }
                }
                else if (necessitaAcessibilidade == 2)
                {
                    if (listaCarros.Count < vagasCarro)
                    {
                        listaCarros.Add(new Carro(placa));
                        Console.WriteLine($"Carro de placa {placa} estacionado.");
                        vagasCarro--;
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, não há vagas disponíveis.");
                    }
                }
                else 
                {
                    Console.WriteLine("Opção inválida. Tente novamente!");
                }
            }
            else if (tipoVeiculo == 2) 
            {
                Console.WriteLine("Digite a placa da moto para estacionar:");
                string placa = Console.ReadLine();

                if (listaMotos.Count < vagasMoto)
                    {
                        listaMotos.Add(new Moto(placa));
                        Console.WriteLine($"Moto de placa {placa} estacionada.");
                        vagasMoto--;
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, não há vagas disponíveis.");
                    }
            } 
            else 
            {
                Console.WriteLine("Opção inválida. Tente novamente!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            Veiculo carro = listaCarros.FirstOrDefault(c => c.Placa.ToUpper() == placa.ToUpper());
            Veiculo moto = listaMotos.FirstOrDefault(m => m.Placa.ToUpper() == placa.ToUpper());

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            int horas = Convert.ToInt32(Console.ReadLine());

            if (carro != null) 
            {
                
                decimal valorTotalCarro = carro.CalcularPreco(horas);
                listaCarros.Remove(carro);
                vagasCarro++;
                Console.WriteLine($"O carro de placa {placa} foi removido e o preço total foi de: R$ {valorTotalCarro}");
            }
            else if (moto != null) 
            {
                decimal valorTotalMoto = moto.CalcularPreco(horas);
                listaMotos.Remove(moto);
                vagasMoto++;
                Console.WriteLine($"A moto de placa {placa} foi removida e o preço total foi de: R$ {valorTotalMoto}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {

            Console.WriteLine("Os veículos estacionados são: ");

            List<Veiculo> listaTodosVeiculos = listaCarros.Concat(listaMotos).ToList();

            int contadorVeiculos = 1;
            foreach (Veiculo veiculo in listaTodosVeiculos)
            {
                Console.WriteLine($"Nº {contadorVeiculos} - Placa: {veiculo.Placa}");
                contadorVeiculos++;
            }

            Console.WriteLine("\n");

            Console.WriteLine($"Vagas para Carro Restantes: {vagasCarro}");
            Console.WriteLine($"Vagas para Moto Restantes: {vagasMoto}");
            Console.WriteLine($"Vagas para Carro com Acessibilidade Restantes: {vagasCarroPcd + vagasCarroIdosos + vagasCarroGestantes}");
        }

        

    }
}