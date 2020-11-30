using System.Text.Json.Serialization;

namespace ElectronicLibrary.Domain.Core.Library
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Booking = 1,
        Cancelled = 2,
        Busy = 3,
        Notified = 4,
        Finished = 5
    }
}
