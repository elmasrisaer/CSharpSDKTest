using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimOkResponse(
    [property:
        JsonPropertyName("esim"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        GetEsimOkResponseEsim? Esim = null
);
