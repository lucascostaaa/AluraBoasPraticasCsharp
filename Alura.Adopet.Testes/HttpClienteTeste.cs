using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes
{
    public class HttpClienteTeste
    {
        [Fact]
        public async void Deve_Retornar_Uma_Lista_Nao_Vazia_Deve_Obter_Sucesso()
        {
            //Arrange
            var clientePet = new HttpClientPet();

            //Act
            var lista = await clientePet.ListPetsAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async void Com_IP_desativada_Deve_Retornar_Erro()
        {
            //Arrange
            var clientePet = new HttpClientPet(uri: "http://localhost:1111");

            //Assert
            await Assert.ThrowsAnyAsync<Exception>(() => clientePet.ListPetsAsync());
        }
    }
}