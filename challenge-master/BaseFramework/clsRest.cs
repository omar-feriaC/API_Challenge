using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
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

        #region GET Response
        public clsHTTP_RESPONSE fnGET(String pstrEndpoint)
        {
            return fnRequest("GET", pstrEndpoint);
        }
        #endregion

        #region POST Response
        public clsHTTP_RESPONSE fnPOST(String pstrEndpoint, String pstrData)
        {
            return fnRequest("POST", pstrEndpoint, pstrData);
        }
        #endregion

        #region HTTP Request Generator
        private clsHTTP_RESPONSE fnRequest(String pstrRequestType, String pstrEndpoint, String pstrBody = null)
        {

            HttpWebRequest objRequest = WebRequest.CreateHttp(strbaseUrl + pstrEndpoint);
            clsHTTP_RESPONSE objResponse = new clsHTTP_RESPONSE();
            Stopwatch objResponseTimer = new Stopwatch();

            byte[] data = null;
            objRequest.Method = pstrRequestType;
            objRequest.ContentType = "application/json";
            objRequest.KeepAlive = false;

            foreach (KeyValuePair<String, String> kvp in headers)
                objRequest.Headers.Add(kvp.Key, kvp.Value);

            if (!String.IsNullOrEmpty(pstrBody))
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                data = encoding.GetBytes(pstrBody);
                objRequest.ContentLength = data.Length;
                Stream newStream = objRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            objResponseTimer.Start();
            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)objRequest.GetResponse())
                    objResponse = fnGetResponseDetails(webResponse);
                objResponse.Time = objResponseTimer.Elapsed;
            }
            catch (WebException exception)
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
            using (DataStream = pwebResponse.GetResponseStream())
            {
                DataReader = new StreamReader(DataStream);
                string Payload = DataReader.ReadToEnd();
                objOutput.StatusCode = pwebResponse.StatusCode;
                objOutput.strMessageBody = Payload;
            }
            return objOutput;
        }
        #endregion

    }

    #region Http Response Class
    public class clsHTTP_RESPONSE
    {
        public HttpStatusCode StatusCode;
        public Dictionary<String,String> Headers;
        public String strMessageBody;
        public TimeSpan Time;

        public clsHTTP_RESPONSE()
        {
            Headers = new Dictionary<String, String>();
        }

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
