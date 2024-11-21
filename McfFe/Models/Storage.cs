using System.ComponentModel.DataAnnotations.Schema;

namespace McfFe.Models
{
    public class Storage
    {
        public int location_id { get; set; }
        public string location_name { get; set; }
    }

    public class StorageLocationModel
    {
        public int location_id { get; set; }
        public string? location_name { get; set; }
    }
}
