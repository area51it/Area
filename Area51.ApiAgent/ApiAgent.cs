using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Area51.ApiAgent
{
    public class ApiAgent
    {
        private readonly string _baseAddress;
        private readonly string _sharedSecretName;
        private readonly bool _hmacSecret;

        public ApiAgent(string baseAddress, string sharedSecretName, bool hmacSecret)
        {
            _baseAddress = baseAddress;
            _sharedSecretName = sharedSecretName;
            _hmacSecret = hmacSecret;
        }

        //private void SetupApiAgent(HttpClient client, string methodName, string apiUrl, T content = null)
        //{
        //    const string secretTokenName = "SecretToken";

        //    client.BaseAddress = new Uri(_baseAddress);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    if (_hmacSecret)
        //    {
        //        // hmac using shared secret a representation of the message, as we are
        //        // including the time in the representation we also need it in the header
        //        // to check at the other end.
        //        // You might want to extend this to also include a username if, for instance,
        //        // the secret key varies by username
        //        client.DefaultRequestHeaders.Date = DateTime.UtcNow;
        //        var datePart = client.DefaultRequestHeaders.Date.Value.UtcDateTime.ToString(CultureInfo.InvariantCulture);

        //        var fullUri = _baseAddress + apiUrl;

        //        var contentMD5 = "";
        //        if (content != null)
        //        {
        //            //var json = new JavaScriptSerializer().Serialize(content);
        //            //contentMD5 = Hashing.GetHashMD5OfString(json);
        //        }

        //        var messageRepresentation =
        //            methodName + "\n" +
        //            contentMD5 + "\n" +
        //            datePart + "\n" +
        //            fullUri;

        //        //var sharedSecretValue = ConfigurationManager.AppSettings[_sharedSecretName];


        //        //client.DefaultRequestHeaders.Add(secretTokenName, hmac);
        //    }
        //    else if (!string.IsNullOrWhiteSpace(_sharedSecretName))
        //    {
        //        //var sharedSecretValue = ConfigurationManager.AppSettings[_sharedSecretName];
        //        //client.DefaultRequestHeaders.Add(secretTokenName, sharedSecretValue);

        //    }
        //}

    }
}
