using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Target;
    public Transform PointA;
    public Transform PointB;
    public AudioSource audioSource;
    public float Time;

    private void Start()
    {
        GameManager.GetInstance().audioSource = audioSource;

        MoveData temp = new MoveData(Target, PointA, PointB, Time);
        GameManager.GetInstance().EnterQueue(temp);

        ShimmerData temp1 = new ShimmerData(Target, Color.white, Time);
        GameManager.GetInstance().EnterQueue(temp1);

        //AddData temp2 = new AddData(Target, "Example");

        StartCoroutine(TestFuction());
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            GameManager.GetInstance().AudioOver = true;
        }
    }

    private IEnumerator TestFuction()
    {
        while (!GameManager.GetInstance().AudioOver||!GameManager.GetInstance().OperationOver)
        {
            yield return null;
        }

        GameManager.GetInstance().PlayAudio();
        GameManager.GetInstance().DoOperation();

        if (GameManager.GetInstance().QueueCount(false) != 0 && GameManager.GetInstance().QueueCount(true) != 0)
        {
            StartCoroutine(TestFuction());
        }
        else if (GameManager.GetInstance().QueueCount(false) != 0)
        {
            StartCoroutine(AudioFuc());
        }
        else if (GameManager.GetInstance().QueueCount(true) != 0)
        {
            StartCoroutine(OperationFuc());
        }
    }

    private IEnumerator AudioFuc()
    {
        while (!GameManager.GetInstance().AudioOver)
        {
            yield return null;
        }

        GameManager.GetInstance().PlayAudio();

        if (GameManager.GetInstance().QueueCount(false) != 0)
        {
            StartCoroutine(AudioFuc());
        }
    }

    private IEnumerator OperationFuc()
    {
        while (!GameManager.GetInstance().OperationOver)
        {
            yield return null;
        }

        GameManager.GetInstance().DoOperation();

        if (GameManager.GetInstance().QueueCount(true) != 0)
        {
            StartCoroutine(OperationFuc());
        }
    }
}