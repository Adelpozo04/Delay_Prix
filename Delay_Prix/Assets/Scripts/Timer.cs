using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    enum TimeFormat
    {
        Hours,
        Minutes,
        Seconds
    }

    [SerializeField] private TimeFormat timeFormat_;

    [SerializeField] private TextMeshProUGUI timeLeft_;

    //Change the representation of the time in screen depending on the format choosen.
    public void ChangeTimeShown(float time)
    {

        float hours;
        float minutes;
        float seconds;

        switch (timeFormat_)
        {

            case TimeFormat.Hours:

                hours = Mathf.Floor(time / 3600);
                minutes = Mathf.Floor((time / 60) % 60);
                seconds = Mathf.Floor(time % 60);

                timeLeft_.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
                break;

            case TimeFormat.Minutes:

                minutes = Mathf.Floor(time / 60);
                seconds = Mathf.Floor(time % 60);

                timeLeft_.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                break;

            case TimeFormat.Seconds:

                seconds = Mathf.Floor(time);

                timeLeft_.text = seconds.ToString();
                
                break;

        }

    }

}
