namespace ASP.NETCoreWebMainAPI.Models
{
    public class Logs
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string TableName { get; set; }
        public int RecordId { get; set; }
        public DateTime LogDate
        {
            get; set;
        }
    }
}
