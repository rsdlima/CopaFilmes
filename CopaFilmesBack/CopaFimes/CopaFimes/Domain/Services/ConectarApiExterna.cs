using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CopaFimes.Domain.Services
{
    public class ConectarApiExterna
    {
        private string urlApiExterna;
        public ConectarApiExterna(string _urlApiExterna)
        {
            urlApiExterna = _urlApiExterna;
        }
        public string Buscar()
        {
            WebRequest request = WebRequest.Create(urlApiExterna);
            request.Method = "GET";
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                return sr.ReadToEnd().ToString();
            }
        }
    }
}
