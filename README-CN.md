# AllInAI.Sharp.API
[![AllInAI.Sharp.API](https://img.shields.io/nuget/v/AllInAI.Sharp.API?style=for-the-badge)](https://www.nuget.org/packages/AllInAI.Sharp.API/)

![](https://img.shields.io/github/stars/raokun/AllInAI.Sharp.API) ![](https://img.shields.io/github/forks/raokun/AllInAI.Sharp.API)


中文简介 | [English](README.md)

[版本更新文档](/Changes/changes.md) | [接口示例文档](/Test/sampleUsage.md) 

AllInAI.Sharp.API一款调用各大平台语言模型的SDK，能帮助使用者快速对接各大模型和向量数据库。已整合OpenAI，chatGLM，文心千帆，同义千问，stable-diffusion，pinecone,pgvector 等
支持设置反向代理,支持流式接口
AllInAI SDK 在聊天和图片接口中整合统一的入参和出参。方便调用。
现在，SDK支持向量库扩展，可以快速实现本地或云端知识库功能。

```
Install-Package AllInAI.Sharp.API
```
## 已完成模型有
- [X] OpenAI
- [X] chatGLM
- [X]文心千帆
- [X] 同义千问
- [X] stable-diffusion
- [ ] midjourney
- [X] pinecone
- [X] pgvector

## 使用范例
### 1.设置基础配置：
key -- 模型的秘钥key
BaseUrl -- 代理地址
AIType -- 模型类型，对应枚举Enums.AITypeEnum

### 2.调用接口
#### 1.聊天类

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
#### 2.图片类

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
#### 3.语音类

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

## 如何贡献
Fork & Clone
Create Feature/name(your github id)/issuexxx branch
Commit with commit message, like solve issue xxx，add xxx
Create Pull Request
如果你希望参与贡献，欢迎 Pull Requests,或给我们 Issues

