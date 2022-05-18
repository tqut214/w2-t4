using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private float timeZone = 1f;
    public bool isSmooth;
    [SerializeField]
    Transform secondHand;
    [SerializeField]
    Transform minuteHand;
    [SerializeField]
    Transform hourHand;

    
    private void Update()
    {
        DateTime currentTime = DateTime.Now;
        Debug.Log(currentTime.ToString());
        float secDegree;
        float minDegree;
        float hourDegree;
        if (isSmooth)
        {
            secDegree = ((float)(currentTime.Second + currentTime.Millisecond / 1000f) / 60f) * 360;
            minDegree = (float)((currentTime.Minute + currentTime.Second / 60f) / 60f) * 360f;
            hourDegree = ((currentTime.Hour + timeZone + currentTime.Minute / 60f) / 12f) * 360f;
            
        }
        else
        {
            secDegree = (currentTime.Second / 60f) * 360f;
            minDegree = (currentTime.Minute / 60f) * 360f;
            hourDegree = ((currentTime.Hour + timeZone ) / 12f) * 360f;
        }
        timeTicky(secDegree, minDegree, hourDegree);


    }
    void timeTicky(float sec, float min, float h)
    {
        secondHand.localRotation = Quaternion.Euler(0, sec, 0);
        minuteHand.localRotation = Quaternion.Euler(0, min, 0);
        hourHand.localRotation = Quaternion.Euler(0, h, 0);
    }
}

