namespace Domain.Agregates
{
    public class Response 
    {
        public object Data { get; set; } = new object();
        public string mesagge { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
    }
}