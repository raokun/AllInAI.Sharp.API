# AllInAI.Sharp.API

[![AllInAI.Sharp.API](https://img.shields.io/nuget/v/AllInAI.Sharp.API?style=for-the-badge)](https://www.nuget.org/packages/AllInAI.Sharp.API/)

![](https://img.shields.io/github/stars/raokun/AllInAI.Sharp.API) ![](https://img.shields.io/github/forks/raokun/AllInAI.Sharp.API)


English | [中文简介](https://github.com/raokun/AllInAI.Sharp.API/blob/main/README-CN.md)

[Update Document](https://github.com/raokun/AllInAI.Sharp.API/blob/main/Changes/changes.md) | [Usage](https://github.com/raokun/AllInAI.Sharp.API/blob/main/Test/sampleUsage.md) 

AllInAI.Sharp.API is an SDK that calls language models from various platforms, and it helps users quickly integrate with major models. It has integrated OpenAI, chatGLM, Wenxin Qianfan, Synonymous Qianwen, stable-diffusion,pinecone，pgvector etc. It supports setting reverse proxies and streaming interfaces.
The AllInAI SDK integrates unified input and output parameters in the chat and image interfaces, making it easy to call.
Now, the SDK supports vector library extension, enabling fast implementation of local or cloud-based knowledge base functionality.

AllInAI.Sharp.API一款调用各大平台语言模型的SDK，能帮助使用者快速对接各大模型和向量数据库。已整合OpenAI，chatGLM，文心千帆，同义千问，stable-diffusion，pinecone,pgvector 等
支持设置反向代理,支持流式接口
AllInAI SDK 在聊天和图片接口中整合统一的入参和出参。方便调用。
现在，SDK支持向量库扩展，可以快速实现本地或云端知识库功能。
```
Install-Package AllInAI.Sharp.API
```
## Completed models include:
- [X] OpenAI
- [X] chatGLM
- [X] Wenxin Qianfan 文心千帆
- [X] Synonymous Qianwen 通义千问
- [X] stable-diffusion
- [ ] midjourney
- [X] pinecone
- [X] pgvector

## Usage example

### 1. Set the basic configurations:
   - key: The model secret key
   - BaseUrl: The proxy address
   - AIType: The model type, corresponds to the Enums.AITypeEnum enumeration

### 2. Call the API
#### 1. chat
```c#
AuthOption authOption = new AuthOption() { Key = "sk-***", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };

ChatService chatService = new ChatService(authOption);
CompletionReq completionReq = new CompletionReq();
List<MessageDto> messages = new List<MessageDto>();
messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
completionReq.Model = "gpt-3.5-turbo";
completionReq.Messages = messages;
CompletionRes completionRes = await chatService.Completion(completionReq);
```
#### 2. image
```c#
AuthOption authOption = new AuthOption() {BaseUrl = "Your api url goes here", AIType = Enums.AITypeEnum.SD };
ImgService imgService = new ImgService(authOption);
Txt2ImgReq imgReq = new Txt2ImgReq();
imgReq.Steps = 20;
imgReq.Size = "1024x1024";
imgReq.N = 1;
imgReq.Prompt = "kitty";
imgReq.ResponseFormat = "b64_json";
ImgRes imgRes = await imgService.Txt2Img(imgReq);
```
#### 3.audio

```c#
AuthOption authOption = new AuthOption() { Key = "sk-***", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };
AudioService audioService = new AudioService(authOption);
AudioSpeechReq req = new AudioSpeechReq() { Model = "tts-1", Input = "你好，我是饶坤，我是AllInAI.Sharp.API的开发者", Voice = "alloy" };
var res = await audioService.Speech<Stream>(req);
if(res.Data != null) {
    var filePath = $"D:/test/{Guid.NewGuid()}.mp3";
    using (FileStream fileStream = File.Create(filePath)) {
        res.Data.CopyTo(fileStream);
    }
}

```


## How to contribute
1. Fork & Clone
2. Create a branch named Feature/name(your github id)/issuexxx
3. Commit with a commit message, like "solve issue xxx, add xxx"
4. Create a Pull Request
If you would like to contribute, feel free to submit Pull Requests or give us Issues.

