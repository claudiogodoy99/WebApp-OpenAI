using Azure;
using Azure.AI.OpenAI;

namespace web_app_openai.Services
{
    public class ClassificationService : IClassificationService
    {
        public async Task<string> Classificar(string text) {


            OpenAIClient client = new OpenAIClient(
                new Uri(""),
                new AzureKeyCredential(""));


            // If streaming is not selected
            Response<Completions> completionsResponse = await client.GetCompletionsAsync(
                deploymentOrModelName: "dpl-2",
                new CompletionsOptions()
                {
                    Prompts = { $"Classifique a avaliação entre (insatisfeito, satisfeito ou neutro): {text}" },
                    Temperature = (float)1,
                    MaxTokens = 100,
                    NucleusSamplingFactor = (float)0.5,
                    FrequencyPenalty = (float)0,
                    PresencePenalty = (float)0,
                    GenerationSampleCount = 1,
                });

            Completions completions = completionsResponse.Value;

            return completions.Choices[0].Text;
        }
    }
}
