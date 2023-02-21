namespace NSE.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
    }

    public class ResponseResult
    {
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; } = null!;
    }

    public class ResponseErrorMessages
    {
        public List<string> Messagens { get; set; } = null!;
    }
}