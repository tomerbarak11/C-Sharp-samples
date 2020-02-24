using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AteraAssignment
{
    class JSONProductsProviderImpl : ProductsProvider
    {
        public List<Product> readProducts()
        {
            List<Product> res = new List<Product>();
            using (StreamReader r = new StreamReader("Products.json"))
            {
                string json = r.ReadToEnd();
                res = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return res;
        }

    }
}
