using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetEsimDeviceOkResponse(
    [property:
        JsonPropertyName("device"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        Device? Device1 = null
);
