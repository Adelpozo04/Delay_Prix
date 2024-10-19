using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    #region parameters

    [Tooltip("It must be in seconds")]
    [SerializeField] private float maxTime_;

    private float currentTime_;

    private int score;

    #endregion

    #region references

    [SerializeField] private GameObject player_;

    #endregion

    #region properties

    private Timer myTimer_;

    private Vector3 current_checkpoint;

    private bool stopTime_ = false;


    static private GameManager instance_;

    public static GameManager Instance { 
        get 
        { 
            return instance_; 
        } 
    }

    #endregion

    public void SetCurrentCheckpoint(Vector3 checkpoint)
    {

        current_checkpoint = checkpoint;

    }

    public void FinishMatch(bool countScore)
    {

        if (countScore)
        {
            score = (int)currentTime_  * 1000;

            PlayerPrefs.SetInt("TestScore", score);
        }

        SceneManager.LoadScene(2);

    }

    public void RestartPlayer()
    {

        player_.GetComponent<CharacterController>().enabled = false;    

        player_.transform.position = current_checkpoint;

        player_.GetComponent<CharacterController>().enabled = true;        

    }

    private void Awake()
    {
        instance_ = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        currentTime_ = maxTime_;
        myTimer_ = GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTime_)
        {
            if (currentTime_ <= 0)
            {
                stopTime_= true;
                FinishMatch(false);
            }
            else
            {
                currentTime_ -= Time.deltaTime;

                myTimer_.ChangeTimeShown(currentTime_);
            }
        }

        

    }
}
