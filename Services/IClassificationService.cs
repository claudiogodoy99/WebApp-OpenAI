namespace web_app_openai.Services
{
    public interface IClassificationService
    {
        Task<string> Classificar(string text);
    }
}
