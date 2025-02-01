namespace MouseTracking.Api.Dtos;

public class MouseMovementDto
{
    public float[] X { get; set; }
    public float[] Y { get; set; }
    public float[] T { get; set; }

    public override string ToString()
    {
        return $"X: {ToString(X)}\nY: {ToString(Y)}\nT: {ToString(T)}";
    }

    private string ToString(float[] array)
    {
        var strs = array.Select(f => f.ToString());
        var res = string.Join(", ", strs);
        return res;
    }
}