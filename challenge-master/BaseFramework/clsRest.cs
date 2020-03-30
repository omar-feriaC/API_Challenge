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
        public clsHTTP_RESPONSE fnGET(String pstrEndpoint)
        {// needs the endpoint to know that to get
            return fnRequest("GET", pstrEndpoint);
        }
        #endregion
        #region POST - Response of a POST
        public clsHTTP_RESPONSE fnPOST(String pstrEndpoint, String pstrData)
        {// needs the endpoint and the possible body to do a post
            return fnRequest("POST", pstrEndpoint, pstrData);
        }
        #endregion
        #region private HTTP Request Generator
        private clsHTTP_RESPONSE fnRequest(String pstrRequestType, String pstrEndpoint, String pstrBody = null)
        {
            HttpWebRequest objRequest = WebRequest.CreateHttp(strbaseUrl + pstrEndpoint);
            clsHTTP_RESPONSE objResponse = new clsHTTP_RESPONSE();
            Stopwatch objResponseTimer = new Stopwatch();
            byte[] data = null;
            objRequest.Method = pstrRequestType; //POST or GET is specified
            objRequest.ContentType = "application/json";
            objRequest.KeepAlive = false;
            foreach (KeyValuePair<String, String> kvp in headers)
            objRequest.Headers.Add(kvp.Key, kvp.Value);
            if (!String.IsNullOrEmpty(pstrBody))// if no NULL do something..
            {   //We should probably add our body to the request's content here
                ASCIIEncoding encoding = new ASCIIEncoding();
                data = encoding.GetBytes(pstrBody);// Create a new string object to POST data to the Url.
                objRequest.ContentLength = data.Length;// Set the content length of the string being posted.
                Stream newStream = objRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();// Close the Stream object.
            }
            objResponseTimer.Start();
            //Once You sent the request(body, try something)
            try //If everything looks good, try this/Read the response
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)objRequest.GetResponse())
                objResponse = fnGetResponseDetails(webResponse); //We need to deserialize the response and be able to print it
                objResponse.Time = objResponseTimer.Elapsed;
            }
            catch (WebException exception) //If there is an exeption, print in here
            {
                if (exception.Status == WebExceptionStatus.ProtocolError)
                {
                    using (HttpWebResponse errResponse = (HttpWebResponse)exception.Response)
                    objResponse = fnGetResponseDetails(errResponse);
                    objResponse.Time = objResponseTimer.Elapsed;
                }
                else throw new Exception(exception.Message);
            }
            objResponseTimer.Stop();
            return objResponse;
        }
        private clsHTTP_RESPONSE fnGetResponseDetails(HttpWebResponse pwebResponse)
        {
            clsHTTP_RESPONSE objOutput = new clsHTTP_RESPONSE();
            //We should probably pull the Http status code and 
            //message body out of the webresposne in here
            //and put it in the HTTP_RESPONSE object.
            using (DataStream = pwebResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                string Payload = DataReader.ReadToEnd();
                objOutput.StatusCode = pwebResponse.StatusCode;
                objOutput.strMessageBody = Payload;
            }
            //pwebResponse.Close();
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