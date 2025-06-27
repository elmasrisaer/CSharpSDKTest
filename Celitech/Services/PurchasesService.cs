using System.Net.Http.Json;
using Celitech.Http;
using Celitech.Http.Exceptions;
using Celitech.Http.Extensions;
using Celitech.Http.Serialization;
using Celitech.Models;
using Celitech.Validation;
using Celitech.Validation.Extensions;

namespace Celitech.Services;

public class PurchasesService : BaseService
{
    internal PurchasesService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<List<CreatePurchaseV2OkResponse>> CreatePurchaseV2Async(
        CreatePurchaseV2Request input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases/v2")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<List<CreatePurchaseV2OkResponse>>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>This endpoint can be used to list all the successful purchases made between a given interval.</summary>
    /// <param name="iccid">ID of the eSIM</param>
    /// <param name="afterDate">Start date of the interval for filtering purchases in the format 'yyyy-MM-dd'</param>
    /// <param name="beforeDate">End date of the interval for filtering purchases in the format 'yyyy-MM-dd'</param>
    /// <param name="referenceId">The referenceId that was provided by the partner during the purchase or topup flow.</param>
    /// <param name="afterCursor">To get the next batch of results, use this parameter. It tells the API where to start fetching data after the last item you received. It helps you avoid repeats and efficiently browse through large sets of data.</param>
    /// <param name="limit">Maximum number of purchases to be returned in the response. The value must be greater than 0 and less than or equal to 100. If not provided, the default value is 20</param>
    /// <param name="after">Epoch value representing the start of the time interval for filtering purchases</param>
    /// <param name="before">Epoch value representing the end of the time interval for filtering purchases</param>
    public async Task<ListPurchasesOkResponse> ListPurchasesAsync(
        string? iccid = null,
        string? afterDate = null,
        string? beforeDate = null,
        string? referenceId = null,
        string? afterCursor = null,
        double? limit = null,
        double? after = null,
        double? before = null,
        CancellationToken cancellationToken = default
    )
    {
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateOptional<string?>((string?)iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "purchases")
            .SetOptionalQueryParameter("iccid", iccid)
            .SetOptionalQueryParameter("afterDate", afterDate)
            .SetOptionalQueryParameter("beforeDate", beforeDate)
            .SetOptionalQueryParameter("referenceId", referenceId)
            .SetOptionalQueryParameter("afterCursor", afterCursor)
            .SetOptionalQueryParameter("limit", limit)
            .SetOptionalQueryParameter("after", after)
            .SetOptionalQueryParameter("before", before)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<ListPurchasesOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<CreatePurchaseOkResponse> CreatePurchaseAsync(
        CreatePurchaseRequest input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<CreatePurchaseOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>This endpoint is used to top-up an eSIM with the previously associated destination by providing an existing ICCID and the package details. The top-up is only feasible for eSIMs in "ENABLED" or "INSTALLED" state. You can check this state using the Get eSIM Status endpoint.</summary>
    public async Task<TopUpEsimOkResponse> TopUpEsimAsync(
        TopUpEsimRequest input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases/topup")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<TopUpEsimOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>This endpoint allows you to modify the dates of an existing package with a future activation start time. Editing can only be performed for packages that have not been activated, and it cannot change the package size. The modification must not change the package duration category to ensure pricing consistency. Duration based packages cannot be edited.</summary>
    public async Task<EditPurchaseOkResponse> EditPurchaseAsync(
        EditPurchaseRequest input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases/edit")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<EditPurchaseOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.</summary>
    /// <param name="purchaseId">ID of the purchase</param>
    public async Task<GetPurchaseConsumptionOkResponse> GetPurchaseConsumptionAsync(
        string purchaseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(purchaseId, nameof(purchaseId));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var purchaseIdValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)purchaseId
        );
        if (purchaseIdValidationResult != null)
        {
            validationResults.Add(purchaseIdValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "purchases/{purchaseId}/consumption")
            .SetPathParameter("purchaseId", purchaseId)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetPurchaseConsumptionOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
