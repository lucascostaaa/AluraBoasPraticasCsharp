using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help", new Help() },
    {"import", new Import() },
    {"list", new List() },
    {"show", new Show() },
};


Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    if(comandosDoSistema.ContainsKey(comando))
    {
        IComando? cmd = comandosDoSistema[comando];
        await cmd.ExeccutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}

