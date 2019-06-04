using AspNetCoreInjecaoDependencia.Models;

namespace AspNetCoreInjecaoDependencia.Services
{
    public interface IMessageService
    {
        bool Send(Message message);
    }
}
