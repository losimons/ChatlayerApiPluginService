using System.Collections.Generic;
using System.Threading.Tasks;
using MicroServ.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroServ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        public LicenseController()
        {

        }

        [HttpGet]
        public async Task<Response> GetVaue()
        {
            var response = new Response();
            var session = new Session();
            var data = new Data();
            data.variable= "testVa";
            session.data = data; 
            session.@namespace = "namespace";
            response.session = session;
            IList<Message> message = new List<Message>();
            IList<TextMessage> textMessage = new List<TextMessage>();
            textMessage.Add( new TextMessage {
                text = "tryout own api"
            });
            var config = new Config();
            config.textMessages = textMessage;
            message.Add(new Message {
                type = "text",
                config = config
            });
            response.messages = message;
            var action = new Action();
            action.nextDialogstate = "d6868da1-3908-4cd5-a9ef-3d57510fc811";
            response.action = action;
            return response;
        }
    }
}