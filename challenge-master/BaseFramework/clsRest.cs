using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using BaseFramework.Model;

namespace BaseFramework.clsRest
{
    public class clsRest
    {
        private String strbaseUrl;
        
        private Dictionary<String,String> headers;
        Stream DataStream;
        StreamReader DataReader;
        StreamWriter DataWriter;

        HttpWebResponse HttpResponse;

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
            return fnRequest("GET", pstrEndpoint);
        }
        #endregion
        #region POST - Response of a POST
        // needs the endpoint and the possible body to do a post
        public clsHTTP_RESPONSE fnPOST(String pstrEndpoint, String pstrData)
        {
            return fnRequest("POST", pstrEndpoint, pstrData);
        }
        #endregion

        #region private HTTP Request Generator
        private clsHTTP_RESPONSE fnRequest(String requestType, String endpoint, String body = null)
        {
            HttpWebRequest request = WebRequest.CreateHttp(strbaseUrl + endpoint);
            clsHTTP_RESPONSE response = new clsHTTP_RESPONSE();
            Stopwatch responseTimer = new Stopwatch();
            //byte[] data = null;
            request.Method = requestType; //POST or GET is specified
            request.ContentType = "application/json";
            request.KeepAlive = false;
            foreach (KeyValuePair<String, String> kvp in headers)
            request.Headers.Add(kvp.Key, kvp.Value);
            if (!String.IsNullOrEmpty(body))// if no NULL do something..
            {   //We should probably add our body to the request's content here
                using (DataStream = request.GetRequestStream())
                {
                    DataWriter = new StreamWriter(DataStream);//We Write the Body
                    DataWriter.Write(body);
                    DataWriter.Flush();
                }
            }
            responseTimer.Start();
            //Once You sent the request(body, try something)
            try //If everything looks good, try this/Read the response
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                response = fnGetResponseDetails(webResponse); //We need to deserialize the response and be able to print it
                response.Time = responseTimer.Elapsed;
            }
            catch (WebException exception) //If there is an exeption, print in here
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    using (HttpWebResponse errResponse = (HttpWebResponse)exception.Response)
                    response = fnGetResponseDetails(errResponse);
                    response.Time = responseTimer.Elapsed;
                }
                else throw new Exception(exception.Message);
            }
            responseTimer.Stop();
            return response;
        }
        private clsHTTP_RESPONSE fnGetResponseDetails(HttpWebResponse pwebResponse)
        {

            clsHTTP_RESPONSE objOutput = new clsHTTP_RESPONSE();

            string Payload;
            
            //We should probably pull the Http status code and 
            //message body out of the webresposne in here
            //and put it in the HTTP_RESPONSE object.
            using (DataStream = pwebResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                Payload = DataReader.ReadToEnd();
                
            }
            pwebResponse.Close();


            return objOutput;
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
        //Function expecting the list of headers to populate
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