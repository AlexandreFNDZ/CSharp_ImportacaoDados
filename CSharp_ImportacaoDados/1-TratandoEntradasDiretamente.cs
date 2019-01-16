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
        static void TratandoEntradasDiretamente()
        {
            var caminhoArquivo = "contas.txt"; // Arquivo Origem dos dados importados.

            using (var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Open)) // USING que implementa método Disposable, que ao final da execução fecha o arquivo utilizado.
            {
                var buffer = new byte[1024]; // Objeto de controle de dados carregados por vez.
                var numBytesLidos = -1;

                while (numBytesLidos != 0)
                {
                    numBytesLidos = fluxoArquivo.Read(buffer, 0, buffer.Length); // Identificar e determinar quais e quantos bytes serão lidos do arquivo de origem.
                    EscreverBuffer(buffer, numBytesLidos);
                }
            }
        }

        /// <summary>
        /// Decodificar os dados byte em texto e escrever na tela do Console.
        /// </summary>
        /// <param name="buffer">Dados de origem, do tipo 'byte'</param>
        /// <param name="numBytesLidos">Número de bytes que serão lidos dos dados de origem</param>
        static void EscreverBuffer(byte[] buffer, int numBytesLidos)
        {
            var utf8 = new UTF8Encoding(); // Objeto de Encoding para transformar os bytes em string.

            var texto = utf8.GetString(buffer, 0, numBytesLidos);
            Console.Write(texto);
        }
    }
}