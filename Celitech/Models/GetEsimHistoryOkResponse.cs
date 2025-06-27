using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimHistoryOkResponse(
    [property:
        JsonPropertyName("esim"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        GetEsimHistoryOkResponseEsim? Esim = null
);
