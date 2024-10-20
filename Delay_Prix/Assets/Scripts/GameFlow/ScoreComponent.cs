using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//Shows the score when the player ends the match, there is plenty of funtionalities to implement but not right now
public class ScoreComponent : MonoBehaviour
{

    #region references

    [SerializeField] private TextMeshProUGUI scoreText_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

        scoreText_.text = "Score: " + PlayerPrefs.GetInt("TestScore");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
