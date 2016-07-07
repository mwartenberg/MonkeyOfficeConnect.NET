using MonkeyOfficeConnectNet.DataItems;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyOfficeConnectNet
{
    public class ApiConnection : IDisposable
    {
        HttpClient hc;

        private ApiConnection()
        {
            
        }

        public static ApiConnection BuildConnection(Uri baseUri, string username, string password)
        {

            ApiConnection apiConnection = new ApiConnection();
            apiConnection.hc = new HttpClient();
            apiConnection.hc.BaseAddress = baseUri;
            var byteArray = Encoding.ASCII.GetBytes(String.Format("{0}:{1}",username,password));
            apiConnection.hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            return apiConnection;

        }



        public async Task<HttpResponseMessage> ExecuteRequest(object requestObject)
        {
            var obj = JsonConvert.SerializeObject(requestObject);
            return await hc.PostAsync("", new StringContent(obj,Encoding.UTF8, "application/json"));
        }

        public async Task<ApiInfoItem> GetApiInfo()
        {
            var res = await ExecuteRequest(new { apiInfoGet = "" });
            res.EnsureSuccessStatusCode();
            string repsonseJson = await res.Content.ReadAsStringAsync();
            JObject exp = JObject.Parse(repsonseJson);


            ApiInfoItem result = JsonConvert.DeserializeObject<ApiInfoItem>(exp["apiInfoGetResponse"]["ReturnData"]["apiInfoItem"].ToString());

            return result;

        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(hc != null)
                    {
                        hc.Dispose();
                    }
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        // ~ApiConnection() {
        //   // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
        //   Dispose(false);
        // }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
