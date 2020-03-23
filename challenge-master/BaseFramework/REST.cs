using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
namespace BaseFramework.Rest
{
    public class clsRest
    {
        private String strbaseUrl;
        private Dictionary<String,String> headers;
        #region REST Constructor
        public clsRest(String pstrurl)
        {
            this.strbaseUrl = pstrurl;
            headers = new Dictionary<String, String>();
        }
        #endregion

        #region Add/Clear Headers
        public void fnClearHeaders()
        {
            headers.Clear();
        }
        public bool fnAddHeader(String pstrkey, String pstrvalue)
        {
            try { headers.Add(pstrkey, pstrvalue); return true; }
            catch (Exception ex){ Debug.WriteLine(ex.Message);  return false; }
        }
        #endregion
        #region GET - Response of a GET
        // needs the endpoint to know that to get
        public clsHTTP_RESPONSE fnGET(String pstrEndpoint)
        {
            return request("GET", pstrEndpoint);
        }
        #endregion
        #region POST - Response of a POST
        // needs the endpoint and the possible body to do a post
        public clsHTTP_RESPONSE fnPOST(String pstrEndpoint, String pstrData)
        {
            return request("POST", pstrEndpoint, pstrData);
        }
        #endregion

        #region private HTTP Request Generator
        private clsHTTP_RESPONSE request(String requestType, String endpoint, String body = null)
        {
            HttpWebRequest request = WebRequest.CreateHttp(strbaseUrl + endpoint);
            clsHTTP_RESPONSE response = new clsHTTP_RESPONSE();
            Stopwatch responseTimer = new Stopwatch();
            //byte[] data = null;
            request.Method = requestType; //This is where POST or GET is specified
            request.ContentType = "application/json";
            request.KeepAlive = false;
            foreach (KeyValuePair<String, String> kvp in headers)
                request.Headers.Add(kvp.Key, kvp.Value);
            if (!String.IsNullOrEmpty(body))// i.e. if Body is abc, this will be false
            {
                //We should probably add our body to the request's content here
                DataWriter = new StreamWriter(DataStream);
                DataWriter.Write(body);
                DataWriter.Flush();
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
        private clsHTTP_RESPONSE getResponseDetails(HttpWebResponse webResponse)
        {
            clsHTTP_RESPONSE output = new clsHTTP_RESPONSE();

            //We should probably pull the Http status code and 
            //message body out of the webresposne in here
            //and put it in the HTTP_RESPONSE object.

            return output;
        }
        #endregion
    }
    #region Http clsResponse Class
    public class clsHTTP_RESPONSE
    {
        public HttpStatusCode StatusCode;
        public Dictionary<String,String> Headers;
        public String strMessageBody;
        public TimeSpan Time;
        //Constructor, just doing an action       
        public clsHTTP_RESPONSE()
        {
            Headers = new Dictionary<String, String>();
        }
        //Function expecting a header to populate those
        public void fnPopulateHeaders(WebHeaderCollection headersIn)
        {
            for (int i = 0; i < headersIn.Count; i++)
            {
                this.Headers.Add(headersIn.Keys[i], headersIn[i]);
            }
        }
    }
    #endregion
}