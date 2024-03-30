using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EnhancedKycVerification.Application.Utilities
{
    public class SignatureGenerator
    {
        IConfiguration _config;

        public SignatureGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateSignature()
        {
            string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", System.Globalization.CultureInfo.InvariantCulture);
            string apiKey = "076933ed-166c-4ffb-b038-e9ac382396a7";
            string partnerID = "433";
            string data = timeStamp + partnerID + "sid_request";

            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] key = utf8.GetBytes(apiKey);
            Byte[] message = utf8.GetBytes(data);

            HMACSHA256 hash = new HMACSHA256(key);
            var signature = hash.ComputeHash(message);

            string result = Convert.ToBase64String(signature);
            return result;
        }
        public string TimestampGenerator()
        {
            string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", System.Globalization.CultureInfo.InvariantCulture);
            return timeStamp;
        }
    }
}

//string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", System.Globalization.CultureInfo.InvariantCulture);
//string apiKey = "076933ed-166c-4ffb-b038-e9ac382396a7";
//string partnerID = "433";
//string data = timeStamp + partnerID + "sid_request";

//UTF8Encoding utf8 = new UTF8Encoding();
//Byte[] key = utf8.GetBytes(apiKey);
//Byte[] message = utf8.GetBytes(data);

//HMACSHA256 hash = new HMACSHA256(key);
//var signature = hash.ComputeHash(message);

//Console.WriteLine(Convert.ToBase64String(signature));
//Console.WriteLine(timeStamp);


//public static Dictionary<String, Object> parse(byte[] json)
//{
//    string jsonStr = Encoding.UTF8.GetString(json);
//    return JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonStr);
//}
//Share
//Console.WriteLine(Convert.ToBase64String(signature));

//var str = System.Text.Encoding.Default.GetString(signature);