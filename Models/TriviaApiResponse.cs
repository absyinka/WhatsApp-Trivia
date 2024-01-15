using Newtonsoft.Json;

namespace WhatsAppTriviaApp.Models;

public class TriviaApiResponse
{
    [JsonProperty("category")]
    public string Category { get; set; } = default!;

    [JsonProperty("correctAnswer")]
    public string CorrectAnswer { get; set; } = default!;

    [JsonProperty("inCorrectAnswers")]
    public List<string> InCorrectAnswers { get; set; } = default!;

    [JsonProperty("question")]
    public string Question { get; set; } = default!;

    [JsonProperty("difficulty")]
    public string Difficulty { get; set; } = default!;
}

public class Question
{
    public string QuestionText { get; set; } = default!;
    public List<(string option, bool isCorrect)> Options { get; set; } = default!;
}
