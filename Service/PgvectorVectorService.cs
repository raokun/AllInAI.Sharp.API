using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res.Vector;
using AllInAI.Sharp.API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AllInAI.Sharp.API.Service
{
    public class PgvectorVectorService : IVectorService
    {
        public async Task ConfigureIndex(HttpClient _httpClient, string name, int? replicas = null, string? podType = null)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateCollection(HttpClient _httpClient, string name, string source)
        {
            throw new NotImplementedException();
        }

        public async Task CreateIndex(HttpClient _httpClient, string name, uint dimension, Metric metric)
        {
            string url = $"/api/v1/Indexs/Upsert";
            var content = new { name };
            await _httpClient.PostAndReadAsStringAsync(url, content, default);
        }

        public  async Task<string> Delete(HttpClient _httpClient, MetadataMap filter, string? indexNamespace = null)
        {
            string url = $"/api/v1/Vectors/Delete";
            var content = new { filter, indexNamespace };
            return await _httpClient.PostAndReadAsAsync<string>(url, content, default);
        }

        public async Task DeleteCollection(HttpClient _httpClient, string name)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteIndex(HttpClient _httpClient, string name)
        {
            string url = $"/api/v1/Indexs/Delete";
            var content=new { name };
            await _httpClient.PostAndReadAsStringAsync(url, content, default);
        }

        public async Task<DescribeCollectionRes> DescribeCollection(HttpClient _httpClient, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<DescribeIndexRes> DescribeIndex(HttpClient _httpClient, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IndexStats> DescribeIndexStats(HttpClient _httpClient)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, VectorDto>> Fetch(HttpClient _httpClient, IEnumerable<string> ids, string? indexNamespace = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> Listcollections(HttpClient _httpClient)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> ListIndexes(HttpClient _httpClient)
        {
            string url = $"api/v1/Indexs/IndexList";
            var content = new {  };
            return await _httpClient.PostAndReadAsAsync<List<string>>(url, content, default);
        }

        public async Task<VectorQueryRes> Query(HttpClient _httpClient, VectorQueryReq req)
        {
            string url = $"api/v1/Vectors/Query";
            return await _httpClient.PostAndReadAsAsync<VectorQueryRes>(url, req, default);
        }

        public async Task Update(HttpClient _httpClient, VectorUpdateReq req)
        {
            string url = $"api/v1/Vectors/Update";
            await _httpClient.PostAndReadAsStringAsync(url, req, default);
        }

        public async Task<VectorUpsertRes> Upsert(HttpClient _httpClient, VectorUpsertReq req)
        {
            string url = "api/v1/Vectors/Upsert";
            return await _httpClient.PostAndReadAsAsync<VectorUpsertRes>(url, req, default);
        }
    }
}
