using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace AzureQnaService
{
    public class AzureFaqQuestion
    {
        private const string AppId = "8f3f7aec-49cb-4071-820f-8400615f0374";
        private const string SubscriptionKey = "cefe1fe2f8764367aaeb21804705b241";

        private static readonly HttpClient Client;

        static AzureFaqQuestion()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
        }
        public async Task<string> GetOneAnswer(string question)
        {
            var questionResponse = await GetTopXAnswer(question, 1);
            return questionResponse.Answers[0].Answer;
        }

        public async Task<QuestionResponse> GetTopXAnswer(string question, int top)
        {
            var uri = "https://westus.api.cognitive.microsoft.com/qnamaker/v2.0/knowledgebases/" + AppId + "/generateAnswer";

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(new { question, top }), Encoding.UTF8, "application/json")
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = await Client.SendAsync(request);
            responseMessage.EnsureSuccessStatusCode();
            var json = await responseMessage.Content.ReadAsStringAsync();
            var questionResponse = JsonConvert.DeserializeObject<QuestionResponse>(json);
            return questionResponse;
        }
    }

    public class QuestionResponse
    {
        public AnswerItem[] Answers { get; set; }
    }

    public class AnswerItem
    {
        public string Answer { get; set; }
        public double Score { get; set; }
    }

}
