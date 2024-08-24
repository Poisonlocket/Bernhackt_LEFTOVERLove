using System.Text.Json.Serialization;

namespace LeftOverLove.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ItemState
{
    Ready = 1,
    Commited = 2,
    Recieved = 3
}
