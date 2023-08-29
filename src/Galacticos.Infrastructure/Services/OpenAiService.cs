using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Application.Services.OpenAI;
using Galacticos.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using OpenAI_API.Models;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace Galacticos.Infrastructure.Services
{
    public class OpenAiService : IOpenAIService
    {
        private readonly OpenAIConfig _openAIConfig;

        public OpenAiService(IOptions<OpenAIConfig> config)
        {
            _openAIConfig = config.Value;
        }
        public async Task<List<string>> GenerateTags(string text, int numTags = 5)
        {
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
            
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("you are a language expert and you are helping me to generate tags for this post based on the text I have provided you. Please provide me with 5 tags that you think are relevant to this post. You can use the text I have provided you to help you generate the tags. When you return the tags, please separate them with a comma. Thank you!");

            chat.AppendUserInput(text);

            var response = await chat.GetResponseFromChatbotAsync();

            var tags = response.Split(",").ToList();

            return tags;
        }
    }
}