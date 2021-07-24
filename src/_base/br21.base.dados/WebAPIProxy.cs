
using Newtonsoft.Json;
using System.Net;


namespace SProfTIAPI.proxy
{
    public class WebAPIProxy
    {

        public static T Get<T>(string url) {  
            try {  
                using(WebClient webClient = new WebClient()) {  
                    //webClient.BaseAddress = url;  
                    var json = webClient.DownloadString(url);  
                    var result = JsonConvert.DeserializeObject<T>(json);  
                    return result;  
                }  
            } catch (WebException ex) {  
                throw ex;  
        }  
    }


    public static T GetWC<T>(string url){
        try
        {
            using (var client = new WebClient()){
                client.Headers[HttpRequestHeader.ContentType] = "applicacio/json";
                client.Headers[HttpRequestHeader.UserAgent] = "User-Agent";
                client.Headers[HttpRequestHeader.Accept] = "*/*";
                var response = client.DownloadString(url);
                response = response.Replace("\"","'").Replace("null","''");
                return JsonConvert.DeserializeObject<T>(response);
            } 
        }
        catch (System.Exception ex)
        {
            throw;
        }
    }

    
    }


}





//https://api.github.com/users?since=1000&per_page=5