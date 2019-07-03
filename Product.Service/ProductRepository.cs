using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Product.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Product.Service
{
    public class ProductRepository : IProductRepository
    {
        public MongoDatabase _database;
        private readonly DataContractJsonSerializer _jsonSerializer;
        private readonly MongoClient _client;

        ~ProductRepository()
        {
        }

        public ProductRepository()
        {
            _client = new MongoClient("mongodb://localhost");
            var server = _client.GetServer();
            _database = server.GetDatabase("ProductsDataBase");
            this._jsonSerializer = new DataContractJsonSerializer(typeof(List<Models.Product>));
        }

        private string GetJsonPath()
        {
            string root = string.Empty;
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (parent != null)
            {
                var directoryInfo = parent.FullName;
                root = directoryInfo.Substring(0, directoryInfo.IndexOf("\\Product"));
            }

            return Path.Combine(root, @"Product\Product.Service\Json\MOCK_DATA.json");
        }

        private string GetJsonContent()
        {
            var path = GetJsonPath();
            return File.ReadAllText(path);
        }

        private List<Models.Product> GetJsonProductList()
        {
            List<Models.Product> products;
            string files = GetJsonContent();

            using (var ms = new MemoryStream(ASCIIEncoding.ASCII.GetBytes((files))))
            {
                products = (List<Models.Product>)_jsonSerializer.ReadObject(ms);
            }

            return products;
        }

        public bool InsertProductMongoCollection()
        {
            var collection = _database.GetCollection<BsonDocument>("Products");
            var doesCollectionExist = collection.Database.CollectionExists("Products");

            try
            {
                if (!doesCollectionExist)
                {
                    var client = new MongoClient();
                    var MongoDB = client.GetDatabase("ProductsDataBase");
                    _database.CreateCollection("Products");

                    var clientCollection = _database.GetCollection<BsonDocument>("Products");

                    var products = GetJsonProductList();
                    var bsonDocumentList = products.Select(product => product.ToBsonDocument()).ToList();

                    foreach (var document in bsonDocumentList)
                    {
                        clientCollection.Insert(document);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return doesCollectionExist;
        }

        public string GetAllProducts()
        {
            var db = _client.GetDatabase("ProductsDataBase");
            var collection = db.GetCollection<BsonDocument>("Products");

            var filter = new BsonDocument();
            var products = collection.Find(filter).ToList();

            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var jsonResult = products.ToJson<List<BsonDocument>>(jsonWriterSettings);

            return jsonResult;
        }

        public string GetProductsFilterPriceMinMax(bool priceAsc, bool? isFantastic)
        {
            var db = _client.GetDatabase("ProductsDataBase");
            var collection = db.GetCollection<BsonDocument>("Products");

            var filter = isFantastic == null ? new BsonDocument() : Builders<BsonDocument>.Filter.Eq("attribute.fantastic.value", isFantastic);
            var sort = priceAsc ? Builders<BsonDocument>.Sort.Ascending("price") : Builders<BsonDocument>.Sort.Descending("price");
            var products = collection.Find(filter).Sort(sort).ToList();

            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var jsonResult = products.ToJson<List<BsonDocument>>(jsonWriterSettings);

            return jsonResult;
        }
        
        public string GetProductsIsFantastic(bool isFantastic)
        {
            var db = _client.GetDatabase("ProductsDataBase");
            var collection = db.GetCollection<BsonDocument>("Products");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("attribute.fantastic.value", isFantastic);
            var products = collection.Find(filter).ToList();

            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var jsonResult = products.ToJson<List<BsonDocument>>(jsonWriterSettings);

            return jsonResult;
        }

        public string GetProductsFilterRatingMinMax(bool ratingAsc, bool? isFantastic)
        {
            var db = _client.GetDatabase("ProductsDataBase");
            var collection = db.GetCollection<BsonDocument>("Products");

            var filter = isFantastic == null ? new BsonDocument() : Builders<BsonDocument>.Filter.Eq("attribute.fantastic.value", isFantastic);
            var sort = ratingAsc ? Builders<BsonDocument>.Sort.Ascending("attribute.rating.value") : Builders<BsonDocument>.Sort.Descending("attribute.rating.value");
            var products = collection.Find(filter).Sort(sort).ToList();

            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var jsonResult = products.ToJson<List<BsonDocument>>(jsonWriterSettings);

            return jsonResult;
        }   
    }
}
