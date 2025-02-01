using System.Text.Json;

namespace Notissimus.PointerTracking.Domain.Dtos;

public class PointerMovementDto
{
    public double[] X { get; set; }
    public double[] Y { get; set; }
    public long[] T { get; set; }

    public override string ToString()
    {
        var opt = new JsonSerializerOptions(JsonSerializerOptions.Default)
        {
            WriteIndented = true
        };
        return JsonSerializer.Serialize(this, opt);
    }
}