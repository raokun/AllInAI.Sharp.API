# Version Changes

## Version
### V1.2.2 NEW! 
  * openai 图片接口添加dallE-3模型支持
### V1.2.1 
  * 添加向量化数据接口添加pgvector支持
### V1.2 
  * 添加向量化数据接口，实现知识库扩展
  * 1.添加 openai 文本嵌入接口embedding。用于文本向量化
  * 2.添加pinecone 向量库接口支持
  * 3.添加文本转向量存储和文本查询示例
### V1.1.8 
  * 修复聊天接口升级产生的bug
### V1.1.7 
  * 基于gpt-4-vision-preview的图文分析

### V1.1.6 
  * 优化stream流式输出时openai没有返回token消耗信息，使用openai的三方库计算token数返回。
  * 修改stable diffusion接口图片大小参数未生效bug
   
### V1.1.5
添加openai 语音文字转换Translations接口,语音转英文
### V1.1.4
添加openai 语音文字转换接口whisper

### V1.1.3
修复文心千帆模型调用模型问题

### V1.1.2
修复文心千帆模型调用返回为空的问题

