using System.Text.Json.Serialization;

namespace Celitech.Models;

public record CreatePurchaseV2Request(
    /// <value>ISO representation of the package's destination.</value>
    [property: JsonPropertyName("destination")]
        string Destination,
    /// <value>
    /// Size of the package in GB.
    ///
    /// For **limited packages**, the available options are: **0.5, 1, 2, 3, 5, 8, 20GB** (supports `duration` or `startDate` / `endDate`).
    ///
    /// For **unlimited packages** (available to Region-3), please use **-1** as an identifier (supports `duration` only).
    /// </value>
    [property: JsonPropertyName("dataLimitInGB")]
        double DataLimitInGb,
    /// <value>Number of eSIMs to purchase.</value>
    [property: JsonPropertyName("quantity")]
        double Quantity,
    /// <value>Email address where the purchase confirmation email will be sent (including QR Code & activation steps)</value>
    [property:
        JsonPropertyName("email"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Email = null,
    /// <value>An identifier provided by the partner to link this purchase to their booking or transaction for analytics and debugging purposes.</value>
    [property:
        JsonPropertyName("referenceId"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ReferenceId = null,
    /// <value>Customize the network brand of the issued eSIM. The `networkBrand` parameter cannot exceed 15 characters in length and must contain only letters and numbers. This feature is available to platforms with Diamond tier only.</value>
    [property:
        JsonPropertyName("networkBrand"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? NetworkBrand = null,
    /// <value>Customize the email subject brand. The `emailBrand` parameter cannot exceed 25 characters in length and must contain only letters, numbers, and spaces. This feature is available to platforms with Diamond tier only.</value>
    [property:
        JsonPropertyName("emailBrand"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? EmailBrand = null
);
