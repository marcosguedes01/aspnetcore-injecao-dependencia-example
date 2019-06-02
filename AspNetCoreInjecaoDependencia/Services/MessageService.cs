using AspNetCoreInjecaoDependencia.Models;

namespace AspNetCoreInjecaoDependencia.Services
{
    public class MessageService
    {
        private readonly Message message;

        public MessageService(Message message)
        {
            this.message = message;
        }

        public bool Send()
        {
            return true;
        }
    }
}
