using System.Text.Json.Serialization;

namespace Celitech.Models;

public record TopUpEsimRequest(
    /// <value>ID of the eSIM</value>
    [property: JsonPropertyName("iccid")]
        string Iccid,
    /// <value>
    /// Size of the package in GB.
    ///
    /// For **limited packages**, the available options are: **0.5, 1, 2, 3, 5, 8, 20GB** (supports `duration` or `startDate` / `endDate`).
    ///
    /// For **unlimited packages** (available to Region-3), please use **-1** as an identifier (supports `duration` only).
    /// </value>
    [property: JsonPropertyName("dataLimitInGB")]
        double DataLimitInGb,
    /// <value>Email address where the purchase confirmation email will be sent (excluding QR Code & activation steps).</value>
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
    /// <value>Customize the email subject brand. The `emailBrand` parameter cannot exceed 25 characters in length and must contain only letters, numbers, and spaces. This feature is available to platforms with Diamond tier only.</value>
    [property:
        JsonPropertyName("emailBrand"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? EmailBrand = null,
    /// <value>Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months.</value>
    [property:
        JsonPropertyName("startTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? StartTime = null,
    /// <value>Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time.</value>
    [property:
        JsonPropertyName("endTime"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? EndTime = null
);
