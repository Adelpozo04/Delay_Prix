using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//Shows the score when the player ends the match, there is plenty of funtionalities to implement but not right now
public class ScoreComponent : MonoBehaviour
{

    enum ValueType
    {
        PlayerPrefsPaths,
        Numerical
    }

    #region properties

    [SerializeField] private TextMeshProUGUI [] scoreTexts_;
    [SerializeField] private ValueType valueType_;
    [SerializeField] private string[] scorePath_;
    [SerializeField] private int[] scoreValues_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if(valueType_ == ValueType.PlayerPrefsPaths)
        {
            for (int i = 0; i < scoreTexts_.Length; i++)
            {

                if (PlayerPrefs.HasKey(scorePath_[i]))
                {
                    scoreTexts_[i].text = "Score: " + PlayerPrefs.GetInt(scorePath_[i]);
                }
                else
                {
                    scoreTexts_[i].text = "Score: " + 0;
                }
                
            }
        }
        else if (valueType_ == ValueType.Numerical)
        {
            for (int i = 0; i < scoreTexts_.Length; i++)
            {
                scoreTexts_[i].text = "Score: " + scoreValues_[i];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
