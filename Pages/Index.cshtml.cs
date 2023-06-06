using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using web_app_openai.Services;

namespace web_app_openai.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IClassificationService _classificationService;

    public string ClassificationResult { get; set; } = string.Empty;
    public string Comentary { get; set; } = string.Empty;

    public IndexModel(ILogger<IndexModel> logger, IClassificationService classificationService)
    {
        _logger = logger;
        _classificationService = classificationService;
    }

    public void OnGet()
    {

    }

    public async Task OnPostClassificar()
    {
        _logger.LogInformation("Messagem chegou");

        string inputTextValue = Request.Form["comentary"];

        if (!string.IsNullOrEmpty(inputTextValue))
        {
            ClassificationResult = "Classificando este comentário";

            ClassificationResult = await _classificationService.Classificar(inputTextValue);
        }

    }
}
