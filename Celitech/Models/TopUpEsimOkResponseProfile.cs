using System.Text.Json.Serialization;

namespace Celitech.Models;

public record TopUpEsimOkResponseProfile(
    /// <value>ID of the eSIM</value>
    [property:
        JsonPropertyName("iccid"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Iccid = null
);
