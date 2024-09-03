using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import",
    documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    internal class Import: IComando
    {
        public async Task ExeccutarAsync(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoArquivoDeImportacao)
        {
            var leitorDeArquivos = new LeitorDeArquivo();
            var listaDePet = leitorDeArquivos.RealizaLeitura(caminhoArquivoDeImportacao);

            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    var httpCreatePet = new HttpClientPet();
                    await httpCreatePet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
