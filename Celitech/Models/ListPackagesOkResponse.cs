using System.Text.Json.Serialization;

namespace Celitech.Models;

public record ListPackagesOkResponse(
    [property:
        JsonPropertyName("packages"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<Packages>? Packages1 = null,
    /// <value>The cursor value representing the end of the current page of results. Use this cursor value as the "afterCursor" parameter in your next request to retrieve the subsequent page of results. It ensures that you continue fetching data from where you left off, facilitating smooth pagination</value>
    [property: JsonPropertyName("afterCursor")]
        string? AfterCursor = null
);
