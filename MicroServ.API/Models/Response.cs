using System.Collections.Generic;
using Newtonsoft.Json;

namespace MicroServ.API.Models
{
    public class Response
    {
        public Session session { get; set; }
        public IList<Message> messages { get; set; }
        public Action action { get; set; }
    }

    public class Session
    {
        public string @namespace { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string variable { get; set; }
    }

    public class TextMessage
    {
        public string text { get; set; }
    }

    public class Config
    {
        public IList<TextMessage> textMessages { get; set; }
    }

    public class Message
    {
        public string type { get; set; }
        public Config config { get; set; }
    }

    public class Action
    {
        public string nextDialogstate { get; set; }
    }
}