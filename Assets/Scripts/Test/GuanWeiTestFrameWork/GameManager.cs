using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    private static Queue<AudioClip> AudioQueue = new Queue<AudioClip>();
    private static Queue<GameData> OperationQueue = new Queue<GameData>();

    public AudioSource audioSource;

    public bool AudioOver = true;
    public bool OperationOver = true;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
            GameManager.instance.AudioEnter();
        }
        return instance;
    }

    private void AudioEnter()
    {
        AudioClip[] temp = Resources.LoadAll<AudioClip>("Audio");
        foreach(AudioClip i in temp)
        {
            EnterQueue(i);
        }
    }

    public void EnterQueue(AudioClip audioclip)
    {
        AudioQueue.Enqueue(audioclip);
    }

    public void EnterQueue(GameData gamedata)
    {
        OperationQueue.Enqueue(gamedata);
    }

    public int QueueCount(bool isOperation)
    {
        return isOperation?OperationQueue.Count:AudioQueue.Count;
    }

    public void PlayAudio()
    {
        AudioOver = false;

        AudioClip temp = AudioQueue.Dequeue();
        Debug.Log("PlayAudio " + temp.name);
        audioSource.clip = temp;
        audioSource.Play();
    }

    public void DoOperation()
    {
        OperationOver = false;

        GameData temp = OperationQueue.Dequeue();
        switch (temp.DataType)
        {
            case (int)Operation.Move:
                MoveData tempmove = (MoveData)temp;
                Move(tempmove.Target, tempmove.PointA, tempmove.PointB, tempmove.Time);
                break;
            case (int)Operation.Shimmer:
                ShimmerData tempShimmer = (ShimmerData)temp;
                Shimmer(tempShimmer.Target, tempShimmer.Time, tempShimmer.color);
                break;
            case (int)Operation.Run:
                Run();
                break;
        }
    }

    #region 操作实现
    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="目标"></param>
    /// <param name="A点"></param>
    /// <param name="B点"></param>
    /// <param name="耗时"></param>
    private void Move(GameObject Target, Transform PointA, Transform PointB, float Time)
    {
        Debug.Log(Target.name + " From " + PointA.name + " To " + PointB.name + " in " + Time + "S");
        OperationOver = true;
    }

    /// <summary>
    /// 闪烁
    /// </summary>
    /// <param name="目标"></param>
    /// <param name="耗时"></param>
    /// <param name="颜色"></param>
    private void Shimmer(GameObject Target, float Time, Color color)
    {
        Debug.Log(Target.name + " is Shimmering " + " in " + Time + "S" + " with " + color);
        OperationOver = true;
    }

    private void Run()
    {
        Debug.Log("run");
        OperationOver = true;
    }
    #endregion
}
