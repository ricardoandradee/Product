using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace Product.xUnit
{
    public static class Validation
    {
        public static bool ValidateJson(this string jsonString)
        {
            try
            {
                JToken.Parse(jsonString);
                return true;
            }
            catch (JsonReaderException ex)
            {
                Trace.WriteLine(ex);
                return false;
            }
        }

        public static List<Models.Product> JsonToProduct(this string jsonString)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                List<Models.Product> products = jss.Deserialize<List<Models.Product>>(jsonString);
                return products;
            }
            catch (JsonReaderException ex)
            {
                Trace.WriteLine(ex);
                return null;
            }
        }
    }
}
