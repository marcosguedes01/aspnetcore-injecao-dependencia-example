using AspNetCoreInjecaoDependencia.Models;

namespace AspNetCoreInjecaoDependencia.Services
{
    public interface IMessageDatabase
    {
        string Type { get; set; }

        Message Message { get; set; }

        void Save();
    }
}
