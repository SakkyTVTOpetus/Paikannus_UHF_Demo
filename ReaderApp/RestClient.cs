using System;
using System.IO;
using System.Net;
using System.Text;

namespace RfidSample
{
    class RestClient
    {
        private string baseUrl;

        public RestClient(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public string Post(string resource, string jsonBody)
        {
            string url = $"{baseUrl}/{resource}";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            byte[] byteData = Encoding.UTF8.GetBytes(jsonBody);
            request.ContentLength = byteData.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteData, 0, byteData.Length);
            }

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        public string Get(string resource, string id = null)
        {
            string url = $"{baseUrl}/{resource}";
            if (!string.IsNullOrEmpty(id))
            {
                url += $"/{id}";
            }

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        public string Put(string resource, string id, string jsonBody)
        {
            string url = $"{baseUrl}/{resource}/{id}";
            WebRequest request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";
            byte[] byteData = Encoding.UTF8.GetBytes(jsonBody);
            request.ContentLength = byteData.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteData, 0, byteData.Length);
            }

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        public string Delete(string resource, string id)
        {
            string url = $"{baseUrl}/{resource}/{id}";
            WebRequest request = WebRequest.Create(url);
            request.Method = "DELETE";
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
