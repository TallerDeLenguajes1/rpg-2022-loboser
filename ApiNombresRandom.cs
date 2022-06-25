// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace RPG
{
     public class ApiOwner
    {
        public string author { get; set; }
        public string cafecito { get; set; }
        public string instagram { get; set; }
        public string github { get; set; }
        public string linkedin { get; set; }
        public string twitter { get; set; }
    }

    public class Body
    {
        public string name { get; set; }
        public string genre { get; set; }
    }

    public class Root
    {
        public ApiOwner api_owner { get; set; }
        public Body body { get; set; }
    }
}