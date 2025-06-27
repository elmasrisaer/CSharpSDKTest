using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Celitech.Http.Extensions;
using Celitech.Http.Serialization;

namespace Celitech.Http;

/// <summary>
/// A builder for creating <see cref="HttpRequestMessage"/> instances with full support for serialization.
/// </summary>
public class RequestBuilder
{
    private readonly string _urlTemplate;

    private readonly HttpMethod _httpMethod;

    private readonly Dictionary<string, string> _pathParameters = new();
    private readonly List<string> _queryParameters = new();
    private readonly Dictionary<string, string> _headers = new();

    private HttpContent? _content;

    private HashSet<string>? _scopes;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestBuilder"/> class.
    /// </summary>
    /// <param name="httpMethod">The HTTP method to use for the request.</param>
    /// <param name="urlTemplate">The URL template to use for the request. Should have path parameters as placeholders surrounded by brackets (Eg. "/users/{id}", where "id" is a path parameter).</param>
    public RequestBuilder(HttpMethod httpMethod, string urlTemplate)
    {
        _httpMethod = httpMethod;
        _urlTemplate = urlTemplate;
    }

    /// <summary>
    /// Sets a path parameter. If the parameter is not present in the URL template, it will be ignored.
    /// </summary>
    public RequestBuilder SetPathParameter(
        string key,
        object value,
        PathSerializationStyle style = PathSerializationStyle.Simple,
        bool explode = false
    )
    {
        var serializedValue = Serializer.Serialize(key, value, (SerializationStyle)style, explode);
        _pathParameters.Add(key, serializedValue);
        return this;
    }

    /// <summary>
    /// Sets a query parameter.
    /// </summary>
    public RequestBuilder SetQueryParameter(
        string key,
        object? value,
        QuerySerializationStyle style = QuerySerializationStyle.Form,
        bool explode = true
    )
    {
        var serializedValue = Serializer.Serialize(key, value, (SerializationStyle)style, explode);
        if (!string.IsNullOrEmpty(serializedValue))
        {
            _queryParameters.Add(serializedValue);
        }
        return this;
    }

    /// <summary>
    /// Sets a query parameter if the value is not null.
    /// </summary>
    public RequestBuilder SetOptionalQueryParameter(
        string key,
        object? value,
        QuerySerializationStyle style = QuerySerializationStyle.Form,
        bool explode = true
    )
    {
        if (value is not null)
        {
            SetQueryParameter(key, value, style, explode);
        }
        return this;
    }

    /// <summary>
    /// Sets a header.
    /// </summary>
    public RequestBuilder SetHeader(string key, object? value, bool explode = false)
    {
        var serializedValue = Serializer.Serialize(key, value, SerializationStyle.Simple, explode);
        if (!string.IsNullOrEmpty(serializedValue))
        {
            _headers.Add(key, serializedValue);
        }
        return this;
    }

    /// <summary>
    /// Sets a header if the value is not null.
    /// </summary>
    public RequestBuilder SetOptionalHeader(string key, object? value, bool explode = false)
    {
        if (value is not null)
        {
            SetHeader(key, value, explode);
        }
        return this;
    }

    /// <summary>
    /// Sets the content of the request as JSON.
    /// </summary>
    public RequestBuilder SetContentAsJson(
        object content,
        JsonSerializerOptions? options = null,
        MediaTypeHeaderValue? mediaType = null
    )
    {
        _content = JsonContent.Create(content, mediaType, options);
        return this;
    }

    /// <summary>
    /// Sets the content of the request as Text.
    /// </summary>
    public RequestBuilder SetContentAsText(
        string content,
        string mediaType,
        Encoding? encoding = null
    )
    {
        encoding ??= Encoding.UTF8;
        _content = new StringContent(content, encoding, mediaType);
        return this;
    }

    /// <summary>
    /// Sets the content of the request as Binary.
    /// </summary>
    public RequestBuilder SetContentAsBinary(byte[] content, MediaTypeHeaderValue mediaType)
    {
        _content = new ByteArrayContent(content);
        _content.Headers.ContentType = mediaType;
        return this;
    }

    /// <summary>
    /// Sets the content of the request as application/x-www-form-urlencoded.
    /// </summary>
    public RequestBuilder SetUrlEncodedContent(
        object content,
        JsonSerializerOptions? options = null
    )
    {
        var jsonContent = JsonSerializer.Serialize(content, options);
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(
            jsonContent,
            options
        );

        if (dictionary is null)
        {
            throw new ArgumentException("Invalid content for form-urlencoded content type.");
        }

        _content = new FormUrlEncodedContent(dictionary);
        return this;
    }

    /// <summary>
    /// Sets the content of the request as multipart/form-data.
    /// </summary>
    public RequestBuilder SetContentAsMultipartFormData(
        object content,
        JsonSerializerOptions? options = null
    )
    {
        _content = new MultipartFormDataContent().AddObject(content, options);
        return this;
    }

    /// <summary>
    /// Sets the scopes for the request.
    /// </summary>
    public RequestBuilder SetScopes(HashSet<string> scopes)
    {
        _scopes = scopes;
        return this;
    }

    private string BuildUrl()
    {
        var url = _urlTemplate;
        foreach (var (key, value) in _pathParameters)
        {
            url = url.Replace($"{{{key}}}", value);
        }

        if (_queryParameters.Any())
        {
            url += "?" + string.Join("&", _queryParameters);
        }

        return url;
    }

    /// <summary>
    /// Builds the <see cref="HttpRequestMessage"/> instance.
    /// </summary>
    public HttpRequestMessage Build()
    {
        var requestMessage = new HttpRequestMessage(_httpMethod, BuildUrl()) { Content = _content };

        foreach (var (key, value) in _headers)
        {
            requestMessage.Headers.Add(key, value);
        }

        if (_scopes is not null)
        {
            requestMessage.SetScopes(_scopes);
        }

        return requestMessage;
    }
}
