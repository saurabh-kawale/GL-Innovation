using OpenAI_API;
using OpenAI_API.Completions;

class Program
{
    static async Task Main(string[] args)
    {
        var openAiApiKey = "Add your key"; // Replace with your OpenAI API key

        APIAuthentication aPIAuthentication = new APIAuthentication(openAiApiKey);
        OpenAIAPI openAiApi = new OpenAIAPI(aPIAuthentication);


        try
        {
            string prompt = "Compose a encouraging poem";
            string model = "gpt-3.5-turbo";
            int maxTokens = 50;

            var completionRequest = new CompletionRequest
            {
                Prompt = prompt,
                Model = model,
                MaxTokens = maxTokens
            };

            var completionResult = await openAiApi.Completions.CreateCompletionAsync(completionRequest);
            var generatedText = completionResult.Completions[0].Text; //completionResult.Choices[0].Text.Trim();

            Console.WriteLine("Generated text:");
            Console.WriteLine(generatedText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}