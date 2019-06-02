using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreInjecaoDependencia.Models;
using AspNetCoreInjecaoDependencia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreInjecaoDependencia.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet, Route("sendmail")]
        public IActionResult SendMailMessage()
        {
            var message = new Message();
            message.From = "from-email@domain.com";
            message.To = "to-email@domain.com";
            message.Subject = "Subject of the email here.";
            message.Body = "Content of the email here.";

            var service = new MessageService(message);

            if (service.Send())
            {
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

            var service = new MessageService(message);

            if (service.Send())
            {
                return AcceptedAtAction("SendPhoneMessage", true);
            }

            return BadRequest("Erro ao enviar mensagem");
        }
    }
}