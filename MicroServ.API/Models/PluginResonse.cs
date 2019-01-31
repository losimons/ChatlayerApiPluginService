// using System.Collections.Generic;
// using Newtonsoft.Json;

// namespace MicroServ.API.Models
// {
//     public class PluginResponse
//     {
//         [JsonProperty("session")]
//         public Session Session { get; set; }
//         [JsonProperty("messages")]
//         public ICollection<Message> Messages { get; set; }
//         [JsonProperty("action")]
//         public Action Action { get; set; }
//     }

//     public class Session
//     {
//         [JsonProperty("namespace")]
//         public string Namespace { get; set; }
//         [JsonProperty("data")]
//         public Data data { get; set; }
//     }

//     public class Data
//     {
//         [JsonProperty("variable")]
//         public string Variable { get; set; }
//     }

//     public class Message
//     {
//         [JsonProperty("type")]
//         public string Type { get; set; }
//         [JsonProperty("textMessages")]
//         public ICollection<TextMessage> TextMessages { get; set; }
//     }

//     public partial class TextMessage
//     {
//         [JsonProperty("text")]
//         public string Text { get; set; }
//     }

//     public class Action
//     {
//         [JsonProperty("nextDialogstate")]

//         public string NextDialogstate { get; set; }
//     }
// }
