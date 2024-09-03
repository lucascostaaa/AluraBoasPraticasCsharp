using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show: IComando
    {
        public Task ExeccutarAsync(string[] args)
        {
            if (args.Length > 1)
            {
                this.MostrarArquivo(caminhoDoArquivoASerExibido: args[1]);
            }
            else
            {
                System.Console.WriteLine("Erro: Caminho do arquivo não fornecido. Use: adopet show <arquivo>");
            }

            return Task.CompletedTask;
        }

        private void MostrarArquivo(string caminhoDoArquivoASerExibido)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo();
            var listaDepets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

            foreach (var pet in listaDepets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
