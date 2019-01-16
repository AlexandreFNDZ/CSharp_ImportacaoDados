using BankOne;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ImportacaoDados
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var caminhoArquivo = "contas.txt"; // Arquivo Origem dos dados importados.

            using (var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Open)) // USING que implementa método Disposable, que ao final da execução fecha o arquivo utilizado.
            using (var leitor = new StreamReader(fluxoArquivo)) // Criar objeto de controle de leitura.
            {
                while (!leitor.EndOfStream) // Continuar até todos os dados serem lidos.
                {
                    var linha = leitor.ReadLine(); // Ler uma linha por vez.
                    var contaCorrente = ConverterStringParaContaCorrente(linha); // Variável que representa um Objeto de ContaCorrente.

                    var mensagem = $"Cliente: {contaCorrente.Titular.Nome} - Ag/Conta nº: {contaCorrente.Agencia}/{contaCorrente.Numero} - Saldo: {contaCorrente.Saldo} _____";
                    Console.WriteLine(mensagem);
                }
            }          

            Console.ReadLine();
        }       

        /// <summary>
        /// Criar um Objeto do tipo ContaCorrente.
        /// </summary>
        /// <param name="linha">Linha de dados lida do arquivo de Origem</param>
        /// <returns></returns>
        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(','); // Coletar os dados separados da linha do arquivo de origem.

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace(".",","));
            var nome = campos[3];

            var titular = new Cliente(); // Criar e atribuir o Objeto do tipo Cliente.
            titular.Nome = nome;

            var resultado = new ContaCorrente(agencia, numero); // Criar e atribuir o Objeto do tipo ContaCorrente.
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado; // Retornar o Objeto completo.
        }
    }
}
