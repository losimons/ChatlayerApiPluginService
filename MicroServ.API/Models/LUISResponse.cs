using System.Collections.Generic;

namespace MicroServ.API.Models
{
    public class LUISResponse
    {
        public string query { get; set; }
        public string alteredQuery { get; set; }
        public TopScoringIntent topScoringIntent { get; set; }
        public ICollection<Intent> intents { get; set; }
        public ICollection<Entity> entities { get; set; }
    }


    public class TopScoringIntent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public double score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public double score { get; set; }
    }
}