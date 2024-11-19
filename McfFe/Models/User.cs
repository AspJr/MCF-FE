using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McfFe.Models
{
    public class User
    {
        public int user_id { get; set; }

        [Required]
        public string user_name { get; set; }

        [Required]
        public string password { get; set; }
        public bool? is_active { get; set; }
    }

    public class ResponseData
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public bool is_active { get; set; }
    }

    public class ApiResponse
    {
        public bool is_success { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
        public ResponseData data { get; set; }
    }

    

}
