using System.Text.Json.Serialization;
using Celitech.Json;

namespace Celitech.Models;

public record GetAccessTokenRequest(
    [property:
        JsonPropertyName("grant_type"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        GrantType? GrantType1 = null,
    [property:
        JsonPropertyName("client_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ClientId = null,
    [property:
        JsonPropertyName("client_secret"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ClientSecret = null
);
