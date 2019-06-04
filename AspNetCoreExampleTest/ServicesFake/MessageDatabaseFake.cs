using AspNetCoreInjecaoDependencia.Models;
using AspNetCoreInjecaoDependencia.Services;

namespace AspNetCoreExampleTest.ServicesFake
{
    class MessageDatabaseFake : IMessageDatabase
    {
        public string Type { get; set; }

        public Message Message { get; set; }

        public void Save()
        {
            // Coloque aqui seu código responsável por salvar os dados.
        }
    }
}
