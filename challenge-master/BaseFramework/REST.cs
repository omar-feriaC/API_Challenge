using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using BaseFramework.Model;

namespace BaseFramework.Rest
{
    public class Rest
    {

        private String baseUrl;
        private Dictionary<String,String> headers;

        string Payload;
        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;

        #region REST Constructor
        public Rest(String url)
        {
            this.baseUrl = url;
            headers = new Dictionary<String, String>(); //header??
        }
        #endregion

        #region Add/Clear Headers
        public void ClearHeaders()
        {
            headers.Clear();
        }
        public bool AddHeader(String key, String value)
        {
            try { headers.Add(key, value); return true; }
            catch (Exception ex){ Debug.WriteLine(ex.Message);  return false; }
        }
        #endregion

        #region GET Request
        public HTTP_RESPONSE GET(String endpoint)
        {
            return request("GET", endpoint);
        }
        #endregion

        #region POST Request
        public HTTP_RESPONSE POST(String endpoint, String data)
        {
           
            return request("POST", endpoint, data);
        }
        #endregion

        #region HTTP Request Generator
        private HTTP_RESPONSE request(String requestType, String endpoint, String body = null)
        {
           
            // Create a request for the URL 
            HttpWebRequest request = WebRequest.CreateHttp(baseUrl + endpoint);
            HTTP_RESPONSE response = new HTTP_RESPONSE();
            Stopwatch responseTimer = new Stopwatch();

            byte[] data = null;
            request.Method = requestType; //Method type: GET/POST
            request.ContentType = "application/json";
            request.KeepAlive = false; //keep connected            
           
                                                       //Header content-type: ap js | host: url
            foreach (KeyValuePair<String, String> kvp in headers)
                request.Headers.Add(kvp.Key, kvp.Value);

            if (!String.IsNullOrEmpty(body))//I dont know what is this for. 
            {
                
                //We should probably add our body to the request's content here
            }

            if (request.Method == "POST" && body != string.Empty)
            {
                using (DataStream = request.GetRequestStream())
                {
                    DataWriter = new StreamWriter(DataStream);
                    DataWriter.Write(body);
                    DataWriter.Flush();
                }

               // response = (HttpWebResponse)request.GetResponse();

            }

            responseTimer.Start();
            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                    response = getResponseDetails(webResponse);

                response.Time = responseTimer.Elapsed;
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    using (HttpWebResponse errResponse = (HttpWebResponse)exception.Response)
                        response = getResponseDetails(errResponse);
                    response.Time = responseTimer.Elapsed;
                }
                else throw new Exception(exception.Message);
            }
            responseTimer.Stop();

            return response;
        }

        private HTTP_RESPONSE getResponseDetails(HttpWebResponse webResponse)
        {
            HTTP_RESPONSE output = new HTTP_RESPONSE();
            
            GetResponse response;

            using (DataStream = webResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                 Payload = DataReader.ReadToEnd();
                //string body = output.MessageBody;
                //body = DataReader.ReadToEnd();
                output.StatusCode = webResponse.StatusCode;
                output.MessageBody = Payload;
                response = JsonConvert.DeserializeObject<GetResponse>(Payload);
                //response = JsonConvert.DeserializeObject<GetResponse>(body);


            }
            webResponse.Close();            
            Console.WriteLine($"Status is: {response.status}");
            foreach (Employee employee in response.data)
            {
                Console.WriteLine($"id: {employee.id}, Name: {employee.employee_name}, Age: {employee.employee_age}");
            }
            //We should probably pull the Http status code and message body out of the webresposne in here
            //and put it in the HTTP_RESPONSE object.
            return output;
        }
        #endregion
    }

    #region Http Response Class
    public class HTTP_RESPONSE
    {
        public HttpStatusCode StatusCode;
        public Dictionary<String,String> Headers;
        public String MessageBody;
        public TimeSpan Time;

        public HTTP_RESPONSE()
        {
            Headers = new Dictionary<String, String>();
        }

        public void PopulateHeaders(WebHeaderCollection headersIn)
        {
            for (int i = 0; i < headersIn.Count; i++)
            {
                this.Headers.Add(headersIn.Keys[i], headersIn[i]);
            }
        }
    }
    #endregion

}
