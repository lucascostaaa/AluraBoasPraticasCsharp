using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class PetApartirDoCsvTeste
    {
        [Fact]
        public void Quando_String_For_Valida_Deve_Retornar_Um_Pet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void Quando_Pet_For_NUll_Deve_Retornar_Exception()
        {
            //Arrange
            string? linha = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void Quando_String_For_Vazia_Deve_Retornar_Exception()
        {
            //Arrange
            string? linha = string.Empty;

            //Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void Quando_Campo_Tipo_For_Invalido_Deve_Retornar_Exception()
        {
            // arrange
            string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41; Lima Limão; 2";

            //assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

    }
}
