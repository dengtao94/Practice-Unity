using UnityEngine;

public class MoveData:GameData
{
    public MoveData(GameObject Target, Transform PointA, Transform PointB, float Time)
    {
        this.DataType = (int)Operation.Move;
        this.Target = Target;
        this.PointA = PointA;
        this.PointB = PointB;
        this.Time = Time;
    }
    public Transform PointA;
    public Transform PointB;
    public float Time;
}