using System.Text.Json.Serialization;

namespace Celitech.Models;

public record ListDestinationsOkResponse(
    [property:
        JsonPropertyName("destinations"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<Destinations>? Destinations1 = null
);
