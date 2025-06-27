using System.Text.Json;
using Celitech.Json;

namespace Celitech.Services;

public class BaseService
{
    protected readonly HttpClient _httpClient;
    protected readonly JsonSerializerOptions _jsonSerializerOptions;

    public BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters = { new ValueEnumJsonConverterFactory() },
        };
    }
}
