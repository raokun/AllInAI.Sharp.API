# AllInAI.Sharp.API

English | [中文简介](https://github.com/raokun/AllInAI.Sharp.API.Sample/blob/main/README-CN.md)

AllInAI.Sharp.API is an SDK that calls language models from various platforms, and it helps users quickly integrate with major models. It has integrated OpenAI, chatGLM, Wenxin Qianfan, Synonymous Qianwen, stable-diffusion, etc. It supports setting reverse proxies and streaming interfaces.
The AllInAI SDK integrates unified input and output parameters in the chat and image interfaces, making it easy to call.

## Completed models include:
* OpenAI
* chatGLM
* Wenxin Qianfan
* Synonymous Qianwen
* stable-diffusion

## Usage example
### Initiate a chat

1. Set the basic configurations:
   - key: The model secret key
   - BaseUrl: The proxy address
   - AIType: The model type, corresponds to the Enums.AITypeEnum enumeration

2. Call the API

1. chat
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
2. image
```c#
AuthOption authOption = new AuthOption() {BaseUrl = "http://43.134.164.127:77", AIType = Enums.AITypeEnum.SD };
ImgService imgService = new ImgService(authOption);
Txt2ImgReq imgReq = new Txt2ImgReq();
imgReq.Steps = 20;
imgReq.Size = "1024x1024";
imgReq.N = 1;
imgReq.Prompt = "kitty";
imgReq.ResponseFormat = "b64_json";
ImgRes imgRes = await imgService.Txt2Img(imgReq);
```

## How to contribute
1. Fork & Clone
2. Create a branch named Feature/name(your github id)/issuexxx
3. Commit with a commit message, like "solve issue xxx, add xxx"
4. Create a Pull Request
If you would like to contribute, feel free to submit Pull Requests or give us Issues.

