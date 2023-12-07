# Usage example

## 1.chat

### 1.Completion

#### 1.OpenAI

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

#### 2.文心千帆

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
#### 3.通义千问

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

### 1.Completion Stream

#### 1.OpenAI

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

#### 2.文心千帆

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
#### 3.通义千问

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

## 1.image

### 1.creatImage

#### 1.OpenAI

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

#### 2.文心千帆

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
#### 3.stable diffusion

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

## 1.audio

### 1.Speech

#### 1.OpenAI
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

### 1.Transcriptions

#### 1.OpenAI
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

