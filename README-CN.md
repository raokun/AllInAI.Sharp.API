# AllInAI.Sharp.API

中文简介 | [English](README.md)

AllInAI.Sharp.API一款调用各大平台语言模型的SDK，能帮助使用者快速对接各大模型。已整合OpenAI，chatGLM，文心千帆，同义千问，stable-diffusion 等
支持设置反向代理,支持流式接口
AllInAI SDK 在聊天和图片接口中整合统一的入参和出参。方便调用。
## 已完成模型有
* OpenAI
* chatGLM
* 文心千帆
* 同义千问
* stable-diffusion

## 使用范例
### 发起聊天

1.设置基础配置：
key -- 模型的秘钥key
BaseUrl -- 代理地址
AIType -- 模型类型，对应枚举Enums.AITypeEnum

2.调用接口
1.chat
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
2.image
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

## 如何贡献
Fork & Clone
Create Feature/name(your github id)/issuexxx branch
Commit with commit message, like solve issue xxx，add xxx
Create Pull Request
如果你希望参与贡献，欢迎 Pull Requests,或给我们 Issues

