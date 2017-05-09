using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioData:GameData{
    public AudioData(GameObject Target)
    {
        this.DataType = (int)Operation.PlayAudio;
        this.Target = Target;
    }
}
