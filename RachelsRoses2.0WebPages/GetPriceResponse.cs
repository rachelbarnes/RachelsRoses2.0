using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json; 

/*note to self, whenever you're having trouble with the Json in using System.Runtime.Serialization.Json, try 
    installing the following in the package manager console

    PM> Install-Package System.Runtime.Serialization.Json
*/
namespace RachelsRoses2._0WebPages{
    [DataContract]
    public class SearchResponse {
        [DataMember(Name = "items")]
        public List<ItemResponse> Items { get; set; }
    }

    [DataContract]
    public class ItemResponse {
        [DataMember(Name = "salePrice")]
        public decimal SalePrice { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }
    }

    //need to rewrite this! Need to understand this!
    /*
      needed componenets: 
      HttpWebRequest
      HttpWebResponse
      DataContracts
      Search Request
      Search Response
    */
    public class GetIngredientResponse {
        public string SerializeItemResponse(string IngredientName, string IngredientSellingSize) {
            var format = new Writer();
            var items = MakeRequest<SearchResponse>(buildSearchRequest(IngredientName)).Items;
            var certainSize = items.Where(item => item.Name.ToLower().Contains(IngredientSellingSize));
            var firstItem = items.First();
            var response = format.FormatString(firstItem);
            return response;
        }
        public static void PrintItem(ItemResponse response, int divisorPricePerOunce) {
            Console.WriteLine("ITEM ID: " + response.ItemId);
            Console.WriteLine("NAME: " + response.Name);
            Console.WriteLine("PRICE: " + response.SalePrice);
            Console.WriteLine("PRICE/OZ: " + response.SalePrice / divisorPricePerOunce);
        }

        public Func<ItemResponse, string[]> GetItemNamePrice = response => {
            string[] ItemNamePricePair = new string[] { };
            ItemNamePricePair[0] = response.Name;
            ItemNamePricePair[1] = response.SalePrice.ToString();
            return ItemNamePricePair;
        };

        public Func<ItemResponse, string> GetItemNamePriceString = response => response.Name + " costs " + response.SalePrice;
       

        public static Func<string, string> buildSearchRequest = IngredientName => String.Format("http://api.walmartlabs.com/v1/search?query={0}&format=json&apiKey={1}", IngredientName, WalmartAPILogKey.key);

        public static Func<string, string> buildItemIDRequest = productID => String.Format("http://api.walmartlabs.com/v1/items/{0}?apiKey={1}&format=json", productID, WalmartAPILogKey.key);

        public static T MakeRequest<T>(string requestUrl) {
            try {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                    return (T)jsonSerializer.ReadObject(response.GetResponseStream());
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }
    }
    public class Writer {

        public Func<ItemResponse, string> FormatString = response => String.Format("{0}: ITEM PRICE: {1:C} ITEM ID: {2}", response.Name, response.SalePrice, response.ItemId); 
    }
}