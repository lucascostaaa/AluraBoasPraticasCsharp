using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public static class PetApartirDoCsv
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não deve ser nulo!");

            if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio.");

            if (propriedades.Length != 3) throw new ArgumentException("Texto Inválido");

            bool sucesso = Guid.TryParse(propriedades[0], out Guid petId);
            if (!sucesso) throw new ArgumentException("GUID inválido");

            sucesso = int.TryParse(propriedades[2], out int tipoPet);
            if (!sucesso) throw new ArgumentException("Tipo de Pet Inválido");

            if (tipoPet != 0 && tipoPet != 1) throw new ArgumentException("Tipo de Pet Inválido!");

            return new Pet(petId,
            propriedades[1],
            tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
            );
        }
    }
}
