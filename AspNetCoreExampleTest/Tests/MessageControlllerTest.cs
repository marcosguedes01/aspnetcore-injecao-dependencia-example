using AspNetCoreExampleTest.ServicesFake;
using AspNetCoreInjecaoDependencia.Controllers;
using AspNetCoreInjecaoDependencia.Models;
using AspNetCoreInjecaoDependencia.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AspNetCoreExampleTest
{
    public class MessageControlllerTest
    {
        private IMessageService service;
        private IMessageDatabase database;
        private MessageController controller;

        public MessageControlllerTest()
        {
            database = new MessageDatabaseFake();

            service = new MessageServiceFake();
            controller = new MessageController(database);
        }

        [Fact]
        public void ShouldSendMailMessage()
        {
            database.Type = "mail";

            var message = new Message();
            message.From = "from-email@domain.com";
            message.To = "to-email@domain.com";
            message.Subject = "Subject of the email here.";
            message.Body = "Content of the email here.";

            var result = controller.SendMailMessage(service, message) as AcceptedAtActionResult;

            Assert.NotNull(result);
            Assert.True((bool)result.Value);
        }

        [Fact]
        public void ShouldSendPhoneMessage()
        {
            database.Type = "phone";

            var message = new Message();
            message.From = "+5581982738474";
            message.To = "+5581982738474";
            message.Subject = "Subject of the message here.";
            message.Body = "Content of the message here.";

            var result = controller.SendPhoneMessage(service, message) as AcceptedAtActionResult;

            Assert.NotNull(result);
            Assert.True((bool)result.Value);
        }
    }
}
