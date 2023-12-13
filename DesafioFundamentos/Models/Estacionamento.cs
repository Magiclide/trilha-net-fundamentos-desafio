


using System.Text.RegularExpressions;





namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if(ValidaPlaca(placa)){
            placa=placa.ToUpper();
            veiculos.Add(placa);
            }else{
                Console.WriteLine("Digite uma placa valida nos moldes brasileiros por favor");
            }
           
        }


        public bool ValidaPlaca(string placa)
        {
        //Expressão regular pensando em placas brasileiras
         string padraoPlaca = @"^[A-Za-z]{3}\d{1}[A-Za-z]{1}\d{2}$|^[A-Za-z]{3}\d{4}$";

        Regex regex = new Regex(padraoPlaca);

        return regex.IsMatch(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

         
            if(ValidaPlaca(placa)){
                placa=placa.ToUpper();
            }else{
                Console.WriteLine("Digite uma placa valida nos moldes brasileiros por favor");
                return;
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string horasEstacionadas=Console.ReadLine();

                if(int.TryParse(horasEstacionadas, out int horasEstacionadasInteiro)){
                    if (horasEstacionadasInteiro > 0)
                    {
                    decimal valorTotal=precoInicial+precoPorHora*horasEstacionadasInteiro;
                    veiculos.Remove(placa); 
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Digite um valor acima de 0 por favor");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um numero inteiro por favor");
                }
               
                        
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
