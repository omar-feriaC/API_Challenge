﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using BaseFramework.Model;

namespace BaseFramework.Rest
{
    public class Rest
    {
        #region Variabe
        public String baseUrl;
        public Dictionary<String, String> headers;
        #endregion

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
        public HTTP_RESPONSE request(String requestType, String endpoint, String body = null)
        {
            //Console.WriteLine(body);
            HttpWebRequest request = WebRequest.CreateHttp(baseUrl + endpoint);
            //Console.WriteLine(baseUrl + endpoint);
            HTTP_RESPONSE response = new HTTP_RESPONSE();
            Stopwatch responseTimer = new Stopwatch();


            byte[] data = null;
            request.Method = requestType;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.KeepAlive = false;

            foreach (KeyValuePair<String, String> kvp in headers)
                request.Headers.Add(kvp.Key, kvp.Value);


            if (!String.IsNullOrEmpty(body))
            {
                //We should probably add our body to the request's content here


                data = ASCIIEncoding.ASCII.GetBytes(body);
                request.ContentLength = data.Length;
                Stream stream = request.GetRequestStream();

                stream.Write(data, 0, data.Length);
                stream.Close();

            }

            responseTimer.Start();
            try
            {
                //HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                    response = getResponseDetails(webResponse);

                //Console.WriteLine("CREATE POST RESPONSE IS: " + response.Headers);
                //Console.WriteLine(response.MessageBody);

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

        public HTTP_RESPONSE getResponseDetails(HttpWebResponse webResponse)
        {
            HTTP_RESPONSE output = new HTTP_RESPONSE();

            //We should probably pull the Http status code and message body out of the webresposne in here
            //and put it in the HTTP_RESPONSE object.

            //Console.WriteLine(((HttpWebResponse)webResponse).StatusDescription);
            StreamReader reader;
            using (var dataStream = webResponse.GetResponseStream())
            {

                reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                output.StatusCode = webResponse.StatusCode;
                output.MessageBody = responseFromServer;

            }

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