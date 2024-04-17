﻿using System.Text.Json;

namespace TestChat.Client.Chat
{
    public class JsonConverter
    {
        public static JsonSerializerOptions JsonSerializerOptions => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public static string Serialize(object value, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return JsonSerializer.Serialize(value, jsonSerializerOptions ?? JsonSerializerOptions); 
        }

        public static TResult Deserialize<TResult>(string serializedString, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return JsonSerializer.Deserialize<TResult>(serializedString, jsonSerializerOptions ?? JsonSerializerOptions);
        }
    }
}
