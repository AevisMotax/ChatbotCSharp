using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;
using Microsoft.Extensions.AI;


namespace ChatbotCSharp.Service
{
    internal class ChatService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private string key { get; set; }

        private String ID {  get; set; }

        

        public ChatService()
        {
            loadkey();
        }


        public void loadkey() 
        {
            try
            {
                //string basePath = AppDomain.CurrentDomain.BaseDirectory; //fix not found error
                string configPath = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");
                var config = File.ReadAllText(configPath);

                var text = JObject.Parse(config);
                this.key = text["OpenAI_API_Key"].ToString();

            } catch(Exception ex) { 
                Console.WriteLine("LOADING_KEY_ERROR:" + ex.Message.ToString());
                //ChatTextBox.AppendText("LOADING_KEY_ERROR:" + ex.Message.ToString());

            }

        }


        public async Task<string> GetReponseFromOpenAI(string input)
        {
            //Load OpenAI completion and connection
            //APIAuthentication aPIAuthentication = new APIAuthentication(key);

            //OpenAIClient openAI = new OpenAIClient(key);
            ChatClient client = new(model: "text-davinci-003", apiKey: key);


            string prompt = input;
            //string model = "text-davinci-003";
            string model = "gpt-3.5-turbo";
            var Messages = new[] 
            {
               new { role = "user", content = input }
            };
            int max_tokens = 50;


            var requestBody = new 
            {
                //prompt = input,
                messages = Messages,
                Model = model,
                MaxTokens = max_tokens,
                temperature = 0.7,
                presence_penalty = 0.2,
            };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject
                (requestBody), Encoding.UTF8, "application/json");

            try
            {
                OpenAI.Chat.ChatCompletion completioin = (client.CompleteChat(input));

                return completioin?.Content[0]?.Text ?? "No response";
                //using (var requestMessage = new
                //    HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions")) 
                //{ 
                //    requestMessage.Headers.
                //        Add("Authorization", $"Bearer {key}");
                //    requestMessage.Content = content;

                //    var response= await httpClient.SendAsync(requestMessage);
                //    response.EnsureSuccessStatusCode();

                //    var responseBody = await response.Content.ReadAsStringAsync();
                //    var responseJson = JObject.Parse(responseBody);

                //    return responseJson["choices"]?[0]?["text"]?.ToString()?.Trim() ?? "No response";
                //}               

            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
                return $"Error {ex.Message}"; 
            }
           
        }

        //If I wish to implement my own Chatbot

    }
}
