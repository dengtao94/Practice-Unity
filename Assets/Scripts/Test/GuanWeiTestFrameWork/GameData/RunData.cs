using UnityEngine;

public class RunData:GameData
{
    public RunData(GameObject Target, Transform PointA, Transform PointB, float Time)
    {
        this.DataType = (int)Operation.Run;
        this.Target = Target;
        this.PointA = PointA;
        this.PointB = PointB;
        this.Time = Time;
    }

    public Transform PointA;
    public Transform PointB;
    public float Time;
}