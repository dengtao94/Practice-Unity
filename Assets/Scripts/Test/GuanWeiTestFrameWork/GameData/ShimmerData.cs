using UnityEngine;

public class ShimmerData:GameData
{
    public ShimmerData(GameObject Target,Color color ,float Time)
    {
        this.DataType = (int)Operation.Shimmer;
        this.Target = Target;
        this.Time = Time;
        this.color = color;
    }
    public float Time;
    public Color color;
}