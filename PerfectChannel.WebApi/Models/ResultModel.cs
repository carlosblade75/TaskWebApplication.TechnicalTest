namespace PerfectChannel.WebApi.Models
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public TaskModel Task { get; set; }
        public string MessageError { get; set; }
    }
}
