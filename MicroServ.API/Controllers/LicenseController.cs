using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MicroServ.API.Business.ServiceContracts;
using MicroServ.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroServ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly INLPService _nlpService;

        public LicenseController(INLPService nlpService)
        {
            _nlpService = nlpService;

        }

        [HttpGet]
        public async Task<Response> GetVaue([FromQuery]string input)
        {
            var department = await _nlpService.GetDepartment(input);

            var response = new Response();
            var session = new Session();
            var data = new Data();
            data.variable = "testVa";
            session.data = data;
            session.@namespace = "namespace";
            response.session = session;
            IList<Message> message = new List<Message>();
            IList<TextMessage> textMessage = new List<TextMessage>();
            textMessage.Add(new TextMessage
            {
                text = department
            });
            var config = new Config();
            config.textMessages = textMessage;
            message.Add(new Message
            {
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