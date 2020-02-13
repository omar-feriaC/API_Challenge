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
using System.Web.Helpers;

namespace BaseFramework.Rest
{
    public class Rest
    {
        private String baseUrl;
        private Dictionary<String,String> headers;

        #region REST Constructor
        public Rest(String url)
        {
            this.baseUrl = url;
            headers = new Dictionary<String, String>();
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
        public HTTP_RESPONSE_GET GET(String endpoint)
        {
            return request_GET("get", endpoint);
        }
        #endregion

        #region POST Request
        public HTTP_RESPONSE POST(String endpoint, String data)
        {
            return request("post", endpoint, data);
        }
        #endregion

        #region HTTP Request Generator
        private HTTP_RESPONSE request(String requestType, String endpoint, String body = null)
        {
            WebRequest request = WebRequest.CreateHttp(baseUrl + endpoint);
            HTTP_RESPONSE response = new HTTP_RESPONSE();
            Stopwatch responseTimer = new Stopwatch();

            byte[] data = null;
            request.Method = requestType;
            request.ContentType = "application/json";
           
            

            foreach (KeyValuePair<String, String> kvp in headers)
                request.Headers.Add(kvp.Key, kvp.Value);

            if (!String.IsNullOrEmpty(body))
            {
                data = Encoding.ASCII.GetBytes(body);
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            responseTimer.Start();
            try
            {
                
                    response = getResponseDetails(request);

                response.Time = responseTimer.Elapsed;
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    using (WebResponse errResponse = (WebResponse)exception.Response)
                    //response = getResponseDetails(errResponse);
                    response.Time = responseTimer.Elapsed;
                }
                else throw new Exception(exception.Message);
            }
            responseTimer.Stop();

            return response;
        }
        private HTTP_RESPONSE_GET request_GET(String requestType, String endpoint, String body = null)
        {
            WebRequest request = WebRequest.CreateHttp(baseUrl + endpoint);
            HTTP_RESPONSE_GET response = new HTTP_RESPONSE_GET();
            Stopwatch responseTimer = new Stopwatch();

            byte[] data = null;
            request.Method = requestType;
            request.ContentType = "application/json";



            foreach (KeyValuePair<String, String> kvp in headers)
                request.Headers.Add(kvp.Key, kvp.Value);

            if (!String.IsNullOrEmpty(body))
            {
                data = Encoding.ASCII.GetBytes(body);
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            responseTimer.Start();
            try
            {

                response = getResponseDetails_GET(request);

                response.Time = responseTimer.Elapsed;
            }
            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    using (WebResponse errResponse = (WebResponse)exception.Response)
                        //response = getResponseDetails(errResponse);
                        response.Time = responseTimer.Elapsed;
                }
                else throw new Exception(exception.Message);
            }
            responseTimer.Stop();

            return response;
        }
        private HTTP_RESPONSE getResponseDetails(WebRequest pwebResponse)
        {
            HTTP_RESPONSE output = new HTTP_RESPONSE();
           
            try
            {
                using (WebResponse webResponse = pwebResponse.GetResponse())
                using (Stream stream = webResponse.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    output = JsonConvert.DeserializeObject<HTTP_RESPONSE>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }

            
            //We should probably pull the Http status code and message body out of the webresposne in here
            //and put it in the HTTP_RESPONSE object.

            return output;
        }
        private HTTP_RESPONSE_GET getResponseDetails_GET(WebRequest pwebResponse)
        {
            HTTP_RESPONSE_GET output = new HTTP_RESPONSE_GET();

            try
            {
                using (WebResponse webResponse = pwebResponse.GetResponse())
                using (Stream stream = webResponse.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    output = JsonConvert.DeserializeObject<HTTP_RESPONSE_GET>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
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
        public HttpStatusCode StatusCode = HttpStatusCode.NotAcceptable;
        public string status {
            get { return StatusCode.ToString(); } set {
                if (value == "success") { StatusCode = HttpStatusCode.OK; }
                else { if (value == "failed") { StatusCode = HttpStatusCode.NonAuthoritativeInformation; } }
            }  }
        public Dictionary<String,String> Headers;
        public string MessageBody;
        public TimeSpan Time;
        public User Data { get; set; }

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
    public class HTTP_RESPONSE_GET
    {
        public HttpStatusCode StatusCode = HttpStatusCode.NotAcceptable;
        public string status
        {
            get { return StatusCode.ToString(); }
            set
            {
                if (value == "success") { StatusCode = HttpStatusCode.OK; }
                else { if (value == "failed") { StatusCode = HttpStatusCode.NonAuthoritativeInformation; } }
            }
        }
        public Dictionary<String, String> Headers;
        public string MessageBody;
        public TimeSpan Time;
        public List<User> Data { get; set; }

        public HTTP_RESPONSE_GET()
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
