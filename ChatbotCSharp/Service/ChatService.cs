using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;


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


        private void loadkey() 
        {
            try
            {

                var config = File.ReadAllText("secrets.json");
                var text = JObject.Parse(config);
                this.key = text["OpenAI_API_Key"].ToString();

            } catch(Exception ex) { Console.WriteLine(ex.Message.ToString());  }

        }




        //If I wish to implement my own Chatbot

    }
}
