using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Overlay : MonoBehaviour
{
    float time = 0.0f;

    int mili = 0;
    int seconds = 0;
    int minute = 0;
    int hours = 3;

    public Text timer;
    public Text date;

    void Update()
    {
        time += Time.deltaTime;
        mili += (int)time;
        if(mili % 60 == 0)
        {
            mili = 0;
            seconds++;
            if(seconds % 60 == 0)
            {
                seconds = 0;
                minute++;
                if(minute % 60 == 0)
                {
                    minute = 0;
                    hours++;
                }
            }
        }
        timer.text = "CAM XX" + "\n" + hours.ToString() + ":" + minute.ToString() + ":" + seconds.ToString() + ":" + mili.ToString();
        date.text = hours.ToString() + ":" + minute.ToString() + "AM" + "\n" + "31/01/2021";
    }
}
