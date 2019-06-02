using AspNetCoreInjecaoDependencia.Models;
using AspNetCoreInjecaoDependencia.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreInjecaoDependencia.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService service;
        private readonly MessageDatabase database;

        public MessageController(MessageService service, MessageDatabase database)
        {
            this.service = service;
            this.database = database;
        }

        [HttpGet, Route("sendmail")]
        public IActionResult SendMailMessage()
        {
            var message = new Message();
            message.From = "from-email@domain.com";
            message.To = "to-email@domain.com";
            message.Subject = "Subject of the email here.";
            message.Body = "Content of the email here.";
            
            if (service.Send(message))
            {
                saveMessageInDatabase("mail", message);

                return AcceptedAtAction("SendMailMessage", true);
            }

            return BadRequest("Erro ao enviar o e-mail");
        }

        [HttpGet, Route("sendmessage")]
        public IActionResult SendPhoneMessage()
        {
            var message = new Message();
            message.From = "+5581982738474";
            message.To = "+5581982738474";
            message.Subject = "Subject of the message here.";
            message.Body = "Content of the message here.";
                        
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