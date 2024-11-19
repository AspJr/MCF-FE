namespace McfFe.Models
{
    public class BpkbResponse
    {
        public bool is_success { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
        public List<ListData> data { get; set; }
    }

    public class ListData
    {
        public int agreement_number { get; set; }
        public string branch_id { get; set; }
        public string bpkb_no { get; set; }
        public DateTime bpkb_date_in { get; set; }
        public DateTime bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public DateTime faktur_date { get; set; }
        public string police_no { get; set; }
        public int location_id { get; set; }
        public int user_id { get; set; }
    }

}
