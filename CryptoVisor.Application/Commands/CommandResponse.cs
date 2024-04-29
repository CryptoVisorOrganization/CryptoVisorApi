namespace CryptoVisor.Application.Commands
{
    public class CommandResponse
    {
        public CommandResponse(string message, bool error, dynamic data)
        {
            Message = message;
            Error = error;
            Data = data;
        }

        public string Message { get; set; }

        public bool Error { get; set; }

        public dynamic Data { get; set; }
    }
}
