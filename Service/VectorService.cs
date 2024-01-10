using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Enums;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Service {
    public class VectorService {
        private readonly HttpClient _httpClient;
        private readonly IVectorService _vectorService;
        public VectorService(AuthOption option, HttpClient? httpClient = null) {

            if (httpClient == null) {
                _httpClient = new HttpClient();
            }
            else {
                _httpClient = httpClient;
            }

            _httpClient.BaseAddress = new Uri(option.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
            switch (option.AIType) {
                case AITypeEnum.Pgvector:
                    _vectorService = new PgvectorVectorService();
                    _httpClient.DefaultRequestHeaders.Add("Api-Key", $"{option.Key}");

                    break;
                case AITypeEnum.Pinecone:
                default:
                    _vectorService = new PineconeVectorService();
                    _httpClient.DefaultRequestHeaders.Add("Api-Key", $"{option.Key}");
                    break;
            }

        }

        public async Task ConfigureIndex(string name, int? replicas = null, string? podType = null) {
             await _vectorService.ConfigureIndex(_httpClient, name, replicas, podType);
        }

        public  Task<string> CreateCollection(string name, string source) {
           return _vectorService.CreateCollection(_httpClient, name, source);
        }

        public Task CreateIndex(string name, uint dimension, Metric metric) {
            return _vectorService.CreateIndex(_httpClient, name, dimension, metric);
        }

        public Task Delete(VectorDeleteReq req) {
            return _vectorService.Delete(_httpClient, req);
        }

        public  Task DeleteCollection(string name) {
            return _vectorService.DeleteCollection(_httpClient, name);
        }

        public  Task DeleteIndex(string name) {
            return _vectorService.DeleteIndex(_httpClient, name);
        }

        public async Task<DescribeCollectionRes> DescribeCollection(string name) {
            return await _vectorService.DescribeCollection(_httpClient, name);
        }

        public async Task<DescribeIndexRes> DescribeIndex(string name) {
            return await _vectorService.DescribeIndex(_httpClient, name);
        }

        public async Task<IndexStats> DescribeIndexStats() {
            return await _vectorService.DescribeIndexStats(_httpClient);
        }

        public async Task<Dictionary<string, VectorDto>> Fetch(IEnumerable<string> ids, string? indexNamespace = null) {
            return await _vectorService.Fetch(_httpClient, ids, indexNamespace);
        }

        public async Task<List<string>> Listcollections() {
            return await _vectorService.Listcollections(_httpClient);
        }

        public async Task<List<string>> ListIndexes() {
            return await _vectorService.ListIndexes(_httpClient);
        }

        public async Task<VectorQueryRes> Query(VectorQueryReq req) {
            return await _vectorService.Query(_httpClient, req);
        }

        public  Task Update(VectorUpdateReq req) {
            return  _vectorService.Update(_httpClient, req);
        }

        public async Task<VectorUpsertRes> Upsert(VectorUpsertReq req) {
            return await _vectorService.Upsert(_httpClient, req);
        }
    }
}
