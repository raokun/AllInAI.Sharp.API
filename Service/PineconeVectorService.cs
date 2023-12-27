using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.IService;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Res.Vector;
using AllInAI.Sharp.API.Utils;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AllInAI.Sharp.API.Service {
    internal class PineconeVectorService : IVectorService {
        public async Task ConfigureIndex(HttpClient _httpClient, string name, int? replicas = null, string? podType = null) {
            string url = $"/databases/{name}";
            var content = new MultipartFormDataContent();
            if(replicas != null) {
                content.Add(new StringContent(replicas.ToString()), "replicas");
            }
            if (replicas != null) {
                content.Add(new StringContent(podType), "pod_type");
            }
            await _httpClient.PatchAndReadAsStringAsync(url,content);
        }

        public async Task<string> CreateCollection(HttpClient _httpClient, string name, string source) {
            string url = "/collections";
            var content = new { name,source };
            return await _httpClient.PostAndReadAsAsync<string>(url, content, default);
        }

        public async Task CreateIndex(HttpClient _httpClient, string name, uint dimension, Metric metric) {

            string url = "/databases";
            var content = new { name, dimension, metric="cosine" };
            await _httpClient.PostAndReadAsStringAsync(url, content, default);
        }

        public async Task<string> Delete(HttpClient _httpClient, MetadataMap filter, string? indexNamespace = null) {
            string url = "/vectors/delete";
            var content = new { filter, indexNamespace };
            return await _httpClient.PostAndReadAsAsync<string>(url, content, default);
        }

        public async Task DeleteCollection(HttpClient _httpClient, string name) {
            string url = $"/collections/{name}";
            await _httpClient.DeleteAndReadAsStringAsync(url, default);
        }

        public async Task DeleteIndex(HttpClient _httpClient, string name) {
            string url = $"/databases/{name}";
            await _httpClient.DeleteAndReadAsStringAsync(url, default);
        }

        public async Task<DescribeCollectionRes> DescribeCollection(HttpClient _httpClient, string name) {
            string url = $"/collections/{name}";
            return await _httpClient.GetAsync<DescribeCollectionRes>(url);
        }

        public async Task<DescribeIndexRes> DescribeIndex(HttpClient _httpClient, string name) {
            string url = $"/databases/{name}";
            return await _httpClient.GetAsync<DescribeIndexRes>(url);
        }

        public async Task<IndexStats> DescribeIndexStats(HttpClient _httpClient) {
            string url = "/describe_index_stats";
            return await _httpClient.PostAndReadAsAsync<IndexStats>(url, default);
        }

        public async Task<Dictionary<string, VectorDto>> Fetch(HttpClient _httpClient, IEnumerable<string> ids, string? indexNamespace = null) {
            using var enumerator = ids.GetEnumerator();
            if (!enumerator.MoveNext()) {
                throw new FormatException("Must contain at least one id");
            }
            var addressBuilder = new StringBuilder("/vectors/fetch")
            .Append("?ids=")
            .Append(UrlEncoder.Default.Encode(enumerator.Current));
            while (enumerator.MoveNext()) {
                addressBuilder.Append("&ids=").Append(UrlEncoder.Default.Encode(enumerator.Current));
            }
            return await _httpClient.GetAsync<Dictionary<string, VectorDto>>(addressBuilder.ToString());
        }

        public async Task<List<string>> Listcollections(HttpClient _httpClient) {
            string url = "/collections";
            return await _httpClient.GetAsync<List<string>>(url);
        }

        public async Task<List<string>> ListIndexes(HttpClient _httpClient) {
            string url = "/databases";
            return await _httpClient.GetAsyncAsList<string>(url);
        }

        public async Task<VectorQueryRes> Query(HttpClient _httpClient, VectorQueryReq req) {
            string url = "/query";
            return await _httpClient.PostAndReadAsAsync<VectorQueryRes>(url, req, default);
        }

        public async Task Update(HttpClient _httpClient, VectorUpdateReq req) {
            string url = "/vectors/update";
             await _httpClient.PostAndReadAsStringAsync(url, req, default);
        }

        public async Task<VectorUpsertRes> Upsert(HttpClient _httpClient, VectorUpsertReq req) {
            string url = "/vectors/upsert";
            return await _httpClient.PostAndReadAsAsync<VectorUpsertRes>(url, req, default);
        }

        private static uint CalculateTotalVectorCount(IndexNamespace[] namespaces) {
            uint totalVectorCount = 0;
            foreach (var ns in namespaces) {
                totalVectorCount += ns.VectorCount;
            }
            return totalVectorCount;
        }
    }
}
