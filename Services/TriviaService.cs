using System.Net;
using Newtonsoft.Json;
using WhatsAppTriviaApp.Models;
namespace WhatsAppTriviaApp.Services;

public class TriviaService
{
    private const string THE_TRIVIA_API_URL = @"https://the-trivia-api.com/api/questions?limit=5";
    private HttpClient _httpClient;

    public TriviaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<TriviaApiResponse>> GetTrivia()
    {
        var response = await _httpClient.GetAsync(THE_TRIVIA_API_URL);
        var triviaJson = await response.Content.ReadAsStringAsync();
        var trivia = JsonConvert.DeserializeObject<IEnumerable<TriviaApiResponse>>(triviaJson);

        return trivia!;
    }

    public List<Question> ConvertTriviaToQuestions(IEnumerable<TriviaApiResponse> questions)
    {
        List<Question> newQuestions = new();
        
        foreach (var question in questions)
        {
            var options = new List<(string option, bool isCorrect)>()
            {
                (question.CorrectAnswer, true),
                (question.InCorrectAnswers[0], false),
                (question.InCorrectAnswers[1], false),
                (question.InCorrectAnswers[2], false)
            };

            Random random = new();

            options = options.OrderBy(_ => random.Next()).ToList();

            newQuestions.Add(new Question { QuestionText = question.Question, Options = options });
        }

        return newQuestions;
    }
}
