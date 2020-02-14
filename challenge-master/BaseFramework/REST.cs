using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using BaseFramework.Model;
using Newtonsoft.Json;

namespace BaseFramework.Rest
{
    public class Rest
    {
        private String baseUrl;
        private Dictionary<String, String> headers;

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
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
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
            var resultCreated = string.Empty;
            HttpWebRequest request = WebRequest.CreateHttp(baseUrl + endpoint);
            HTTP_RESPONSE response = new HTTP_RESPONSE();
            Stopwatch responseTimer = new Stopwatch();

            byte[] data = null;
            request.Method = requestType;
            request.ContentType = "application/json";
            request.KeepAlive = false;

            foreach (KeyValuePair<String, String> kvp in headers)
                request.Headers.Add(kvp.Key, kvp.Value);

            if (!String.IsNullOrEmpty(body))
            {
                data = Encoding.UTF8.GetBytes(body);
                //Stream stream = request.GetRequestStream();
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(body);
                }
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();


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
            StreamReader streamReader;

            using (var dataStream = webResponse.GetResponseStream())
            {
                streamReader = new StreamReader(dataStream);
                string resultCreated = streamReader.ReadToEnd();
                
                output.StatusCode = webResponse.StatusCode;
                output.MessageBody = resultCreated;
            }

            //output.StatusCode = webResponse.StatusCode;
            //output.MessageBody = webResponse.
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
        public Dictionary<String, String> Headers;
        public String MessageBody;
        public MemberGetData memberGetData;
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
