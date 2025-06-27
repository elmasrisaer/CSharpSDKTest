using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimMacOkResponse(
    [property:
        JsonPropertyName("esim"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        GetEsimMacOkResponseEsim? Esim = null
);
