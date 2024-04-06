using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Muscles_app.Services
{
    public static class Client
    {
        public static HttpClientHandler handler { 
            get 
            { 
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true;};
                return clientHandler;           
            } // opravq certifikati nz kak (dark magic)
        }
            
    
    public readonly static HttpClient _httpClient = new HttpClient(handler);

        public readonly static string _url = "https://10.0.2.2:7004/";

    }
}
