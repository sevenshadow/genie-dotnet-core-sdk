using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace SevenShadow.Genie
{
    public class GenieHelper
    {
        #region Private Variables

        private string _genieBottleUrl;

        #endregion  

        #region Constructors

        public GenieHelper(string genieBottleUrl)
        {
            _genieBottleUrl = genieBottleUrl;
        }

        #endregion

        #region Genie Methods

        public async Task<JObject> ShowStatus()
        {
            return await InvokeCallAsync(GenieMethod.ShowStatus);
        }

        public async Task<JObject> Ping()
        {
            return await InvokeCallAsync(GenieMethod.Ping);
        }

        public async Task<JObject> ClearSystemMemory()
        {
            return await InvokeCallAsync(GenieMethod.ClearSystemMemory);
        }

        public async Task<JObject> ClearAllMemory()
        {
            return await InvokeCallAsync(GenieMethod.ClearAllMemory);
        }

        #endregion

        #region Private Methods

        private async Task<JObject> InvokeCallAsync(GenieMethod method)
        {

            JObject jsonrequest = new JObject();
            var json = new JObject(
                new JProperty("jsonrpc", "1.0"),
                new JProperty("method", GetEnumDescription(method)),
                new JProperty("id", 1),
                new JProperty("params", new int[] { })
            );

            var httpContent = new StringContent(json.ToString());
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(_genieBottleUrl, httpContent);
            response.EnsureSuccessStatusCode();
            string responseBodyAsText = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(responseBodyAsText);
           
            return jsonObject;

        }

        private static String GetEnumDescription(Enum e)
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] enumAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (enumAttributes.Length > 0)
            {
                return enumAttributes[0].Description;
            }
            return e.ToString();
        }

        #endregion
    }

    
}
