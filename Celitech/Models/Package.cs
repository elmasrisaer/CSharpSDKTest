using System.Text.Json.Serialization;

namespace Celitech.Models;

public record Package(
    /// <value>ID of the package</value>
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Id = null,
    /// <value>
    /// Size of the package in bytes. For **limited packages**, this field will return the data limit in bytes. For **unlimited packages**, it will return **-1** as an identifier.
    /// </value>
    [property:
        JsonPropertyName("dataLimitInBytes"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DataLimitInBytes = null,
    /// <value>ISO representation of the package's destination.</value>
    [property:
        JsonPropertyName("destination"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Destination = null,
    /// <value>Name of the package's destination</value>
    [property:
        JsonPropertyName("destinationName"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? DestinationName = null,
    /// <value>Price of the package in cents</value>
    [property:
        JsonPropertyName("priceInCents"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? PriceInCents = null
);
