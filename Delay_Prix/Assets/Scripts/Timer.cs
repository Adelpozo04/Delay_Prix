using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
