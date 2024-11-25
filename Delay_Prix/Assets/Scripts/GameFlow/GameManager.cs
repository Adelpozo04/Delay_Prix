using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//class that controls all the game flow during a match
public class GameManager : MonoBehaviour
{


    #region parameters

    [Tooltip("It must be in seconds")]
    [SerializeField] private float maxTime_;

    [SerializeField] private int pointsPerSecond_ = 100;

    private float currentTime_;

    private int score_;

    #endregion

    #region references

    [SerializeField] private GameObject player_;

    #endregion

    #region properties

    private Timer myTimer_;

    private Vector3 current_checkpoint;

    private bool stopTime_ = false;

    private string sceneName_;


    static private GameManager instance_;

    public static GameManager Instance { 
        get 
        { 
            return instance_; 
        } 
    }

    #endregion

    //Set the current checkpoint of the player
    public void SetCurrentCheckpoint(Vector3 checkpoint)
    {

        current_checkpoint = checkpoint;

    }

    //Finish the match counting the score depending on if the player ran out of time or if he reached the goal
    public void FinishMatch(bool countScore, int sceneIndex)
    {

        if (countScore)
        {
            Debug.Log(currentTime_);

            PlayerPrefs.SetInt("TestScore", 0);

            score_ += PlayerPrefs.GetInt("TestScore") + ((int)currentTime_  * pointsPerSecond_);

            PlayerPrefs.SetInt("TestScore", score_);
        }
        else
        {
            PlayerPrefs.SetInt("TestScore", 0);
        }

        PlayerPrefs.SetString("LastScene", sceneName_);

        SceneManager.LoadScene(sceneIndex);

    }

    public void AddScore(int score)
    {

        score_ += score;

    }

    //Returns the player to the checkpoint
    //It has to disable the character controller in order to stop its position change during the teleport
    public void RestartPlayer()
    {

        player_.GetComponent<RagDollState>().DisableRagDoll();

        player_.GetComponent<CharacterController>().enabled = false;    

        player_.transform.position = current_checkpoint;

        player_.GetComponent<CharacterController>().enabled = true;        

    }

    //Make thhe GameManager a singletone
    private void Awake()
    {
        instance_ = this;

        sceneName_ = SceneManager.GetActiveScene().name;
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
        //check the time of the match and update the timer
        if (!stopTime_)
        {
            if (currentTime_ <= 0)
            {
                stopTime_= true;
                FinishMatch(false, 2);
            }
            else
            {
                currentTime_ -= Time.deltaTime;

                myTimer_.ChangeTimeShown(currentTime_);
            }
        }

        

    }
}
