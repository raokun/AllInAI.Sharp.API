# Usage example

## 1. Chat

### 1. Completion

#### 1. OpenAI

```c#
 public async Task OpenAIChatServiceTest() {
    AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };

    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
    completionReq.Model = "gpt-3.5-turbo";
    completionReq.Messages = messages;
    CompletionRes completionRes = await chatService.Completion(completionReq);
    if (completionRes.Error != null) {
        Console.WriteLine(completionRes.Error.Message);
    }
    else {
        Console.WriteLine(completionRes);
    }
}
```

#### 2. 文心千帆

```c#
public async Task BaiduCompletionTest() {
    AuthService authService = new AuthService("https://aip.baidubce.com");
    var token = await authService.GetTokenAsyncForBaidu("your API Key", "your Secret Key");
    AuthOption authOption = new AuthOption() { Key = token.access_token, BaseUrl = "https://aip.baidubce.com", AIType = Enums.AITypeEnum.Baidu };

    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
    completionReq.Model = BaiduModels.Qianfan_BLOOMZ_7B_compressed;
    completionReq.Messages = messages;
    CompletionRes completionRes = await chatService.Completion(completionReq);
    if (completionRes.Error != null) {
        Console.WriteLine(completionRes.Error.Message);
    }
    else {
        Console.WriteLine(completionRes);
    }
}
```
#### 3. 通义千问

```c#
public async Task AliCompletionTest() {

    AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = " https://dashscope.aliyuncs.com", AIType = Enums.AITypeEnum.Ali };

    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
    completionReq.Model = "qwen-turbo";
    completionReq.Messages = messages;
    CompletionRes completionRes = await chatService.Completion(completionReq);
    if (completionRes.Error != null) {
        Console.WriteLine(completionRes.Error.Message);
    }
    else {
        Console.WriteLine(completionRes);
    }
}
```

### 2. Completion Stream

#### 1. OpenAI

```c#
 public async Task OpenAICompletionStreamTest() {
    AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
    completionReq.Model = "gpt-3.5-turbo";
    completionReq.Messages = messages;
    var enumerable = chatService.CompletionStream(completionReq);
    //接口返回的完整内容
    string totalMsg = "";
    await foreach (var item in enumerable) {
        totalMsg += item.Result;
    }
}
```

#### 2. 文心千帆

```c#
public async Task BaiduCompletionStreamTest() {
    AuthService authService = new AuthService("https://aip.baidubce.com");
    var token = await authService.GetTokenAsyncForBaidu("your API Key", "your Secret Key");
    AuthOption authOption = new AuthOption() { Key = token.access_token, BaseUrl = "https://aip.baidubce.com", AIType = Enums.AITypeEnum.Baidu };

    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    messages.Add(new MessageDto() { Role = "user", Content = "你是哪个公司的?" });
    messages.Add(new MessageDto() { Role = "system", Content = "你是饶坤公司制作的AI助手" });
    completionReq.Model = BaiduModels.ERNIE_Bot_turbo_AI;
    completionReq.Messages = messages;
    var enumerable = chatService.CompletionStream(completionReq);
    //接口返回的完整内容
    string totalMsg = "";
    await foreach (var item in enumerable) {
        totalMsg += item.Result;
    }
}
```
#### 3. 通义千问

```c#
public async Task AliCompletionStreamTest() {

    AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = " https://dashscope.aliyuncs.com", AIType = Enums.AITypeEnum.Ali };

    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
    completionReq.Model = "qwen-turbo";
    completionReq.Messages = messages;
    var enumerable = chatService.CompletionStream(completionReq);
    //接口返回的完整内容
    string totalMsg = "";
    await foreach (var item in enumerable) {
        totalMsg += item.Result;
    }
}
```

### 3. Image and text analysis

#### 1. OpenAI

```c#
public async Task Gpt4OpenAIcompletionsTest() {
    AuthOption authOption = new AuthOption() { Key = "sk-****", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
    ChatService chatService = new ChatService(authOption);
    CompletionReq completionReq = new CompletionReq();
    List<MessageDto> messages = new List<MessageDto>();
    List<MessageContent>? Contents=new List<MessageContent>();
    Contents.Add(MessageContent.TextContent("What’s in this image?"));
    Contents.Add(MessageContent.ImageUrlContent("https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"));
    messages.Add(new MessageDto() { Role = "user", Contents= Contents });
    completionReq.Model = "gpt-4-vision-preview";
    completionReq.Messages = messages;
    var enumerable = chatService.CompletionStream(completionReq);
    //接口返回的完整内容
    string totalMsg = "";
    await foreach (var item in enumerable) {
        totalMsg += item.Result;
    }
}
```

### 4. Embedding

#### 1. OpenAI

```c#
public async Task EmbeddingTest() {
    AuthOption authOption = new AuthOption() { Key = "sk-****", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
    ChatService chatService = new ChatService(authOption);
    EmbeddingReq req = new EmbeddingReq();
    req.Model = "text-embedding-ada-002";
    req.Input = "今天是2023年12月26日";
    var res =await chatService.Embedding(req);
    //接口返回的完整内容
    if (res.Error != null) {
        Console.WriteLine(res.Error.Message);
    }
    else {
        Console.WriteLine(res);
    }
}
```



## 2. Image

### 1. creatImage

#### 1. OpenAI

```c#
public async Task OpenAIImgTest() {
    AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };

    ImgService imgService = new ImgService(authOption);
    Txt2ImgReq imgReq = new Txt2ImgReq();
    imgReq.Steps = 20;
    imgReq.Size = "1024x1024";
    imgReq.N = 1;
    imgReq.Prompt = "kitty";
    imgReq.ResponseFormat = "b64_json";
    ImgRes imgRes = await imgService.Txt2Img(imgReq);
    if (imgRes.Error != null) {
        Console.WriteLine(imgRes.Error.Message);
    }
    else {
        if (imgRes.Results.Count > 0) {
            foreach (var item in imgRes.Results) {
                var filePath = $"D:/test/{Guid.NewGuid()}.png";
                var imageData = Convert.FromBase64String(item.B64);
                await System.IO.File.WriteAllBytesAsync(filePath, imageData);
            }
        }
        Console.WriteLine(imgRes);
    }
}
```

#### 2. 文心千帆

```c#
 public async Task BaiduImgTest() {
    try {
        AuthService authService = new AuthService("https://aip.baidubce.com");
        var token = await authService.GetTokenAsyncForBaidu("your API Key", "your Secret Key");
        AuthOption authOption = new AuthOption() { Key = token.access_token, BaseUrl = "https://aip.baidubce.com", AIType = Enums.AITypeEnum.Baidu };

        ImgService imgService = new ImgService(authOption);
        Txt2ImgReq imgReq = new Txt2ImgReq();
        imgReq.Steps = 20;
        imgReq.Size = "1024x1024";
        imgReq.N = 1;
        imgReq.Prompt = "kitty";
        imgReq.ResponseFormat = "b64_json";
        ImgRes imgRes = await imgService.Txt2Img(imgReq);
        if (imgRes.Error != null) {
            Console.WriteLine(imgRes.Error.Message);
        }
        else {
            if (imgRes.Results.Count > 0) {
                foreach (var item in imgRes.Results) {
                    var filePath = $"D:/test/{Guid.NewGuid()}.png";
                    var imageData = Convert.FromBase64String(item.B64);
                    await System.IO.File.WriteAllBytesAsync(filePath, imageData);
                }
            }
            Console.WriteLine(imgRes);
        }
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
    }
}
```
#### 3. stable diffusion

```c#
public async Task SDImgTest() {
    try {

        AuthOption authOption = new AuthOption() { BaseUrl = "your api url there", AIType = Enums.AITypeEnum.SD };
        ImgService imgService = new ImgService(authOption);
        Txt2ImgReq imgReq = new Txt2ImgReq();
        imgReq.Steps = 20;
        imgReq.Size = "1024x1024";
        imgReq.N = 1;
        imgReq.Prompt = "kitty";
        imgReq.ResponseFormat = "b64_json";
        ImgRes imgRes = await imgService.Txt2Img(imgReq);
        if (imgRes.Error != null) {
            Console.WriteLine(imgRes.Error.Message);
        }
        else {
            if (imgRes.Results.Count > 0) {
                foreach (var item in imgRes.Results) {
                    var filePath = $"D:/test/{Guid.NewGuid()}.png";
                    var imageData = Convert.FromBase64String(item.B64);
                    await System.IO.File.WriteAllBytesAsync(filePath, imageData);
                }
            }
            Console.WriteLine(imgRes);
        }
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
    }
}
```

## 3. Audio

### 1. Speech

#### 1. OpenAI
```c#
public async Task OpenAISpeechTest() {
    try {
        AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
        AudioService audioService = new AudioService(authOption);
        AudioSpeechReq req = new AudioSpeechReq() { Model = "tts-1", Input = "你好，我是饶坤，我是AllInAI.Sharp.API的开发者", Voice = "alloy" };
        var res = await audioService.Speech<Stream>(req);
        if(res.Data != null) {
            var filePath = $"D:/test/{Guid.NewGuid()}.mp3";
            using (FileStream fileStream = File.Create(filePath)) {
                res.Data.CopyTo(fileStream);
            }
        }
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
    }
}
```

### 2. Transcriptions

#### 1. OpenAI
```c#
public async Task OpenAITranscriptionsTest() {
    try {
        AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
        // 读取音频文件的二进制内容
        byte[] audioData = File.ReadAllBytes("C:/Users/Administrator/Desktop/response.mp3");
        AudioService audioService = new AudioService(authOption) ;
        AudioCreateTranscriptionReq req = new AudioCreateTranscriptionReq() { File=audioData,FileName= "response.mp3",Model= "whisper-1" ,Language="zh"};
        AudioTranscriptionRes res = await audioService.Transcriptions(req);
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
    }
}
```

### 3. Translations

#### 1. OpenAI
```c#
public async Task OpenAITranslationsTest() {
    try {
        AuthOption authOption = new AuthOption() { Key = "sk-**", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
        // 读取音频文件的二进制内容
        byte[] audioData = File.ReadAllBytes("C:/Users/Administrator/Desktop/response.mp3");
        AudioService audioService = new AudioService(authOption) ;
        AudioCreateTranscriptionReq req = new AudioCreateTranscriptionReq() { File=audioData,FileName= "response.mp3",Model= "whisper-1" ,Language="zh"};
        AudioTranscriptionRes res = await audioService.Translations(req);
    }
    catch (Exception e) {
        Console.WriteLine(e.Message);
    }
}
```



## 4.Vector

### 1. ListIndexes

```c#
[TestMethod()]
public async Task PineconeListIndexesTest() {
    try {
        string namespacename = "gcp-starter";// Your ENVIRONMENT
        string baseUrl = $"https://controller.{namespacename}.pinecone.io/databases";
        AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);
        var res = await vectorService.ListIndexes();
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```

### 2. CreateIndex

```c#
[TestMethod()]
public async Task PineconeCreateIndexTest() {
    try {
        var indexName = "test-index";
        string namespacename = "gcp-starter";// Your ENVIRONMENT
        string baseUrl = $"https://controller.{namespacename}.pinecone.io/databases";
        AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);
        await vectorService.CreateIndex(indexName,1536, Metric.Cosine);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```

### 3. DeleteIndex

```c#
[TestMethod()]
public async Task PineconeDeleteIndexTest() {
    try {
        var indexName = "test-index";
        string namespacename = "gcp-starter";// Your ENVIRONMENT
        string baseUrl = $"https://controller.{namespacename}.pinecone.io/databases";
        AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);
        await vectorService.DeleteIndex(indexName);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```

### 4. DescribeIndex

```c#
[TestMethod()]
public async Task PineconeDescribeIndexTest() {
    try {
        var indexName = "test-index";
        string namespacename = "gcp-starter";// Your ENVIRONMENT
        string baseUrl = $"https://controller.{namespacename}.pinecone.io/databases";
        AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);
        var res = await vectorService.DescribeIndex(indexName);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```

### 5. ConfigureIndex

```c#
[TestMethod()]
public async Task PineconeConfigureIndexTest() {
    try {
        var indexName = "test-index";
        string namespacename = "gcp-starter";// Your ENVIRONMENT
        string baseUrl = $"https://controller.{namespacename}.pinecone.io/databases";
        AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);
        await vectorService.ConfigureIndex(indexName,1);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```

### 6. DescribeIndex

```c#
[TestMethod()]
        public async Task PineconeDescribeIndexStatsTest() {
            try {
                var host = "your host";
                string baseUrl = $"https://{host}";
                AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
                VectorService vectorService = new VectorService(authOption);
                var res=await vectorService.DescribeIndexStats();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
```

### 7. Upsert

```c#
[TestMethod()]
        public async Task PineconeUpsertTest() {
            try {
                var host = "your host";
                string baseUrl = $"https://{host}";
                AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
                VectorService vectorService = new VectorService(authOption);
                string namespacename = "test-namespace";
                var first = new VectorDto {
                    Id = "first1",
                    // Zeroed-out placeholder vector, this is where you put the embeddings unless using sparse vectors
                    Values = new float[1536],
                    Metadata = new() {
                        ["new"] = true,
                        ["price"] = 50,
                        ["tags"] = new string[] { "tag1", "tag2" }
                    }
                };

                var second = new VectorDto {
                    Id = "second2",
                    Values = new float[1536],
                    Metadata = new() { ["price"] = 100 }
                };
                var req = new VectorUpsertReq {
                    Vectors = new[] { first , second },
                    Namespace = namespacename ?? ""
                };
                var json = System.Text.Json.JsonSerializer.Serialize(req);
                var res = await vectorService.Upsert(req);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
```

### 8. Update

```c#
[TestMethod()]
        public async Task PineconeUpdateTest() {
            try {
                var host = "your host";
                string baseUrl = $"https://{host}";
                AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
                VectorService vectorService = new VectorService(authOption);
                VectorUpdateReq req = new VectorUpdateReq() { Id = "second", Values = null, SetMetadata = new() { ["price"] = 101 } ,Namespace= "test-namespace" };
                await vectorService.Update(req);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
```

### 9. Query

```c#
[TestMethod()]
public async Task PineconeQueryTest() {
    try {
        var host = "your host";
        string baseUrl = $"https://{host}";
        AuthOption authOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);
        var priceRange = new MetadataMap {
            ["price"] = new MetadataMap {
                ["$gte"] = 75,
                ["$lte"] = 125
            }
        };
        VectorQueryReq req = new VectorQueryReq() { Vector = new float[1536], TopK = 3, IncludeMetadata = true, Filter = priceRange };

        var res = await vectorService.Query(req);
        var g = res.Matches.SelectMany(v => v.Metadata!);
    }
    catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```



## 5. Use for KnowledgeBase

### 1.Upsert Data

```c#
[TestMethod()]
public async Task KnowledgeBaseTest() {
    try {
        //文本转向量
        AuthOption authOption = new AuthOption() { Key = "sk-****", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
        ChatService chatService = new ChatService(authOption);
        EmbeddingReq req = new EmbeddingReq();
        req.Model = "text-embedding-ada-002";
        req.Input = "今天是2023年12月26日";
        var embeddingOgj = await chatService.Embedding(req);
        //接口返回的完整内容
        if (embeddingOgj.Error != null) {
            Console.WriteLine(embeddingOgj.Error.Message);
            return;
        }
        else {
            Console.WriteLine(embeddingOgj);
        }
        if (!(embeddingOgj.Data.Count() > 0)) {
            return;
        }
        //获取向量库
        //1.查询向量库
        var indexName = "test-index";
        string namespacename = "gcp-starter";// Your ENVIRONMENT
        string baseUrl = $"https://controller.{namespacename}.pinecone.io";
        AuthOption vectorAuthOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorBaseService = new VectorService(vectorAuthOption);
        var indexRes = await vectorBaseService.DescribeIndex(indexName);
        if(indexRes.Status.Host == null) {
            return;
        }
        embeddingOgj.Data.ForEach(async embedding => {
            //添加向量
            string hostUrl = $"https://{indexRes.Status.Host}";
            VectorService vectorService = new VectorService(vectorAuthOption);
            string openaispace = "openaispace";
            var dto = new VectorDto() { Id = "first1", Values = embedding.Embedding,Metadata= new() { ["input"] = req.Input } };
            var upsertReq = new VectorUpsertReq {
                Vectors = new[] { dto },
                Namespace = openaispace ?? ""
            };
            var json = System.Text.Json.JsonSerializer.Serialize(upsertReq);
            var res = await  vectorService.Upsert(upsertReq);
        });

    } catch (Exception ex) {
        Console.WriteLine(ex.Message);
    }
}
```



### 2. Query Data

```c#
[TestMethod]
public async Task chatQuerytest() {
    try {
        //文本转向量
        AuthOption authOption = new AuthOption() { Key = "sk-****", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
        ChatService chatService = new ChatService(authOption);
        EmbeddingReq req = new EmbeddingReq();
        req.Model = "text-embedding-ada-002";
        req.Input = "今天是几年几月几号";
        var embeddingOgj = await chatService.Embedding(req);
        var host = "your host";
        string baseUrl = $"https://{host}";
        AuthOption vectorAuthOption = new AuthOption() { Key = "your API Key", BaseUrl = baseUrl, AIType = Enums.AITypeEnum.Pinecone };
        VectorService vectorService = new VectorService(authOption);

        embeddingOgj.Data.ForEach(async embedding => {
            string openaispace = "test-namespace";
            var queryReq = new VectorQueryReq {
                Vector = embedding.Embedding,
                TopK=1,
                Namespace = openaispace ?? ""
            };
            var json = System.Text.Json.JsonSerializer.Serialize(queryReq);
            var res = await vectorService.Query(queryReq);
        });
    }
    catch (Exception ex) 
    { 
        Console.WriteLine(ex.Message); 
    }
}
```

