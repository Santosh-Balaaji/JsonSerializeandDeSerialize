using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace JsonSerialize
{
    public class Program
    {
        public void LoadJson()
        {
            string messages = File.ReadAllText(@"C:\Users\SantoshS\source\repos\JsonSerialize\JsonSerialize\messages.json");
            dynamic messagesObject = (JObject)JsonConvert.DeserializeObject<dynamic>(messages);
            string desc = null;
            string languageFile = File.ReadAllText(@"C:\Users\SantoshS\source\repos\JsonSerialize\JsonSerialize\de.json");
            dynamic languageObject = (JObject)JsonConvert.DeserializeObject<dynamic>(languageFile);
            
             foreach (JProperty lang_key in languageObject)
             {
                 foreach (JProperty message_key in messagesObject)
                 {
                    if (String.Equals(Convert.ToString(lang_key.Name), Convert.ToString(messagesObject[message_key.Name].id)))
                    {
                        JsonClass jsonObj = new JsonClass();
                        jsonObj.Title = message_key.Name;
                        if (messagesObject[message_key.Name].desc != null)
                        {
                            desc = messagesObject[message_key.Name].desc.ToString();
                        }
                        else
                        {
                            desc = "";
                        }
                        jsonObj.Description = desc;
                       
                        jsonObj.Messages = languageObject[lang_key.Name].Value;
                        string jsonConvert = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"C:\Users\SantoshS\source\repos\JsonSerialize\JsonSerialize\german.json", jsonConvert);
                        Console.WriteLine("Line Written");
                    }
                    
                 }
             }

        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.LoadJson();
        }
    }
    public class JsonClass {
        public String Title { get; set; }
        public String Messages { get; set; }
        public String Description { get; set; }
    }
}
