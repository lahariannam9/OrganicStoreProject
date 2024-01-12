using System.ComponentModel.DataAnnotations;

namespace OrganicStore.Models
{
    public class fruitsInventory
    {
        public int code { get; set; }
        public string name { get; set; }
        public string stock { get; set; }
    }
}
