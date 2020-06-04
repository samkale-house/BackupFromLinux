using System;
using System.IO;            //Needs to be added
using System.Net;           //Needs to be added
using System.Text;          //Needs to be added

namespace AjaxAtClientPrj.Models
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }   

        //Default Constructor
        public RestClient()
        {
            endPoint = "";
            httpMethod = httpVerb.GET;
            
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            var request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();
            
            HttpWebResponse response = null;

            try 
            {
                response = (HttpWebResponse)request.GetResponse();
                

                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //We catch non Http 200 responses here.
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if(response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
            
        }
    }
}