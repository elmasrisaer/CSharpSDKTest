using System.Net.Http.Json;
using Celitech.Http;
using Celitech.Http.Exceptions;
using Celitech.Http.Extensions;
using Celitech.Http.Serialization;
using Celitech.Models;
using Celitech.Validation;
using Celitech.Validation.Extensions;

namespace Celitech.Services;

public class IFrameService : BaseService
{
    internal IFrameService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>Generate a new token to be used in the iFrame</summary>
    public async Task<TokenOkResponse> TokenAsync(CancellationToken cancellationToken = default)
    {
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Post, "iframe/token")
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<TokenOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
