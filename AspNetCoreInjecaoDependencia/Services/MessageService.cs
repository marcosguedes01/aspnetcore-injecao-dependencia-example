using AspNetCoreInjecaoDependencia.Models;

namespace AspNetCoreInjecaoDependencia.Services
{
    public class MessageService : IMessageService
    {
        public bool Send(Message message)
        {
            return true;
        }
    }
}
