using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AllInAI.Sharp.API.IService {
    internal interface IVectorService {
        #region Index
        /// <summary>
        /// This operation returns a list of your Pinecone collections.
        /// </summary>
        /// <returns></returns>
        Task<List<string>> Listcollections(HttpClient _httpClient);
        /// <summary>
        /// This operation creates a Pinecone collection. Not supported by projects on the gcp-starter environment.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        Task<string> CreateCollection(HttpClient _httpClient,string name, string source);
        /// <summary>
        /// Get a description of a collection.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<DescribeCollectionRes> DescribeCollection(HttpClient _httpClient,string name);
        /// <summary>
        /// This operation deletes an existing collection.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task DeleteCollection(HttpClient _httpClient,string name);
        /// <summary>
        /// This operation returns a list of your Pinecone indexes.
        /// </summary>
        /// <returns></returns>
        Task<List<string>> ListIndexes(HttpClient _httpClient);
        /// <summary>
        /// This operation creates a Pinecone index. You can use it to specify the measure of similarity, the dimension of vectors to be stored in the index, the numbers of replicas to use, and more.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dimension"></param>
        /// <param name="metric"></param>
        /// <returns></returns>
        Task CreateIndex(HttpClient _httpClient,string name, uint dimension, Metric metric);

        Task<DescribeIndexRes> DescribeIndex(HttpClient _httpClient,string name);
        Task DeleteIndex(HttpClient _httpClient,string name);
        Task ConfigureIndex(HttpClient _httpClient,string name, int? replicas = null, string? podType = null);
        #endregion
        #region vector
        /// <summary>
        /// The DescribeIndexStats operation returns statistics about the index's contents, including the vector count per namespace and the number of dimensions.
        /// </summary>
        /// <returns></returns>
        Task<IndexStats> DescribeIndexStats(HttpClient _httpClient);
        /// <summary>
        /// The Query operation searches a namespace, using a query vector.It retrieves the ids of the most similar items in a namespace, along with their similarity scores.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<VectorQueryRes> Query(HttpClient _httpClient,VectorQueryReq req);
        /// <summary>
        /// The Delete operation deletes vectors, by id, from a single namespace.You can delete items by their id, from a single namespace.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="indexNamespace"></param>
        /// <returns></returns>
        Task<string> Delete(HttpClient _httpClient,MetadataMap filter, string? indexNamespace = null);
        Task<VectorUpsertRes> Upsert(HttpClient _httpClient,VectorUpsertReq req);

        Task Update(HttpClient _httpClient, VectorUpdateReq req);
        Task<Dictionary<string, VectorDto>> Fetch(HttpClient _httpClient,IEnumerable<string> ids, string? indexNamespace = null);
        #endregion
    }
}
