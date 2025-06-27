using System.Text.Json.Serialization;

namespace Celitech.Models;

public record TopUpEsimOkResponsePurchase(
    /// <value>ID of the purchase</value>
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Id = null,
    /// <value>ID of the package</value>
    [property:
        JsonPropertyName("packageId"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? PackageId = null,
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
        double? EndTime = null
);
