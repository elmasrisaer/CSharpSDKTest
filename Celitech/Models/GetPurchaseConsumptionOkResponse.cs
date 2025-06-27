using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetPurchaseConsumptionOkResponse(
    /// <value>
    /// Remaining balance of the package in byte.
    /// For **limited packages**, this field indicates the remaining data in bytes.
    /// For **unlimited packages**, it will return **-1** as an identifier.
    /// </value>
    [property:
        JsonPropertyName("dataUsageRemainingInBytes"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DataUsageRemainingInBytes = null,
    /// <value>Status of the connectivity, possible values are 'ACTIVE' or 'NOT_ACTIVE'</value>
    [property:
        JsonPropertyName("status"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Status = null
);
