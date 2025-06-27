using System.Text.Json.Serialization;

namespace Celitech.Models;

public record CreatePurchaseOkResponseProfile(
    /// <value>ID of the eSIM</value>
    [property:
        JsonPropertyName("iccid"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Iccid = null,
    /// <value>QR Code of the eSIM as base64</value>
    [property:
        JsonPropertyName("activationCode"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ActivationCode = null,
    /// <value>Manual Activation Code of the eSIM</value>
    [property:
        JsonPropertyName("manualActivationCode"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ManualActivationCode = null
);
