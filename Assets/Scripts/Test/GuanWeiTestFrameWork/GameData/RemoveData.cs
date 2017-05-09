using System;
using UnityEngine;

public class RemoveData : GameData {
    public RemoveData(GameObject Target, string Component)
    {
        this.DataType = (int)Operation.RemoveComponent;
        this.Target = Target;
        Type t = Type.GetType(Component);
        Destroy(Target.GetComponent(t));
    }
}
