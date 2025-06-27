using System.Text.Json.Serialization;

namespace Celitech.Models;

public record Purchases(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Id = null,
    /// <value>Start date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("startDate")]
        string? StartDate = null,
    /// <value>End date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property: JsonPropertyName("endDate")]
        string? EndDate = null,
    /// <value>It designates the number of days the eSIM is valid for within 90-day validity from issuance date.</value>
    [property: JsonPropertyName("duration")]
        double? Duration = null,
    /// <value>Creation date of the purchase in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [property:
        JsonPropertyName("createdDate"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? CreatedDate = null,
    /// <value>Epoch value representing the start time of the package's validity</value>
    [property: JsonPropertyName("startTime")]
        double? StartTime = null,
    /// <value>Epoch value representing the end time of the package's validity</value>
    [property: JsonPropertyName("endTime")]
        double? EndTime = null,
    /// <value>Epoch value representing the date of creation of the purchase</value>
    [property:
        JsonPropertyName("createdAt"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? CreatedAt = null,
    [property:
        JsonPropertyName("package"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        Package? Package1 = null,
    [property:
        JsonPropertyName("esim"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        PurchasesEsim? Esim = null,
    /// <value>The `source` indicates whether the purchase was made from the API, dashboard, landing-page, promo-page or iframe. For purchases made before September 8, 2023, the value will be displayed as 'Not available'.</value>
    [property:
        JsonPropertyName("source"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Source = null,
    /// <value>The `purchaseType` indicates whether this is the initial purchase that creates the eSIM (First Purchase) or a subsequent top-up on an existing eSIM (Top-up Purchase).</value>
    [property:
        JsonPropertyName("purchaseType"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? PurchaseType = null,
    /// <value>The `referenceId` that was provided by the partner during the purchase or top-up flow. This identifier can be used for analytics and debugging purposes.</value>
    [property:
        JsonPropertyName("referenceId"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ReferenceId = null
);
