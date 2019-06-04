using AspNetCoreInjecaoDependencia.Models;

namespace AspNetCoreInjecaoDependencia.Services
{
    public class MessageDatabase : IMessageDatabase
    {
        public string Type { get; set; }

        public Message Message { get; set; }

        public void Save()
        {
            // Código para salvar na base de dados.
        }
    }
}
