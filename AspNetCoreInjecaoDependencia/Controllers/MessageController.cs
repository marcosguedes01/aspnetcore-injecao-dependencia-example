using AspNetCoreInjecaoDependencia.Models;
using AspNetCoreInjecaoDependencia.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreInjecaoDependencia.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageDatabase database;

        public MessageController(IMessageDatabase database)
        {
            this.database = database;
        }

        [HttpGet, Route("sendmail")]
        public IActionResult SendMailMessage([FromServices] IMessageService service, Message message)
        {            
            if (service.Send(message))
            {
                saveMessageInDatabase("mail", message);

                return AcceptedAtAction("SendMailMessage", true);
            }

            return BadRequest("Erro ao enviar o e-mail");
        }

        [HttpGet, Route("sendmessage")]
        public IActionResult SendPhoneMessage([FromServices] IMessageService service, Message message)
        {                        
            if (service.Send(message))
            {
                saveMessageInDatabase("phone", message);

                return AcceptedAtAction("SendPhoneMessage", true);
            }

            return BadRequest("Erro ao enviar mensagem");
        }

        private void saveMessageInDatabase(string type, Message message)
        {
            database.Type = type;
            database.Message = message;
            database.Save();
        }
    }
}