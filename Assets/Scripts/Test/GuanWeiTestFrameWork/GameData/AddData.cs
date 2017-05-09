using System;
using UnityEngine;

public class AddData : GameData {

    public AddData(GameObject Target, string Component)
    {
        this.DataType = (int)Operation.AddComponent;
        this.Target = Target;
        Type t = Type.GetType(Component);
        Target.AddComponent(t);
    }
}
