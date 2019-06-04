using AspNetCoreInjecaoDependencia.Models;
using AspNetCoreInjecaoDependencia.Services;

namespace AspNetCoreExampleTest.ServicesFake
{
    class MessageServiceFake : IMessageService
    {
        public bool Send(Message message)
        {
            // Coloque aqui seu código responsável por enviar as mensagens.
            return true;
        }
    }
}
