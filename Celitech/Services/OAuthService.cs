using System.Net.Http.Headers;
using System.Net.Http.Json;
using Celitech.Http;
using Celitech.Http.Exceptions;
using Celitech.Http.Extensions;
using Celitech.Http.Serialization;
using Celitech.Models;
using Celitech.Validation;
using Celitech.Validation.Extensions;

namespace Celitech.Services;

public class OAuthService : BaseService
{
    internal OAuthService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>This endpoint was added by liblab</summary>
    public async Task<GetAccessTokenOkResponse> GetAccessTokenAsync(
        GetAccessTokenRequest input,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Post, "oauth2/token")
            .SetUrlEncodedContent(input, _jsonSerializerOptions)
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetAccessTokenOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
