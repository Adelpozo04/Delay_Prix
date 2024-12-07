using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    #region parameters

    [SerializeField] private int [] minUnlockScore_;

    #endregion

    #region properties

    [SerializeField] private string[] levelsScorePath_;

    #endregion

    #region references

    [SerializeField] private GameObject[] levelsReference_;

    [SerializeField] private GameObject[] difficultyButtons_ = new GameObject[3];

    #endregion

    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("LevelDiff", difficulty);

        for (int i = 0; i < difficultyButtons_.Length; ++i)
        {
            if (i + 1 == difficulty)
            {
                difficultyButtons_[i].GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                difficultyButtons_[i].GetComponent<Image>().color = Color.white;
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
        if(minUnlockScore_.Length == levelsScorePath_.Length && minUnlockScore_.Length == levelsReference_.Length)
        {

            for (int i = 0; i < minUnlockScore_.Length; i++)
            {

                if (!(PlayerPrefs.GetInt(levelsScorePath_[i]) >= minUnlockScore_[i]))
                {
                    levelsReference_[i].GetComponent<Button>().enabled = false;
                    levelsReference_[i].GetComponent<Image>().color = Color.gray;
                }

            }

        }
        else
        {
            Debug.LogError("not same size in levels info");
        }

        if (PlayerPrefs.HasKey("LevelDiff"))
        {
            for (int i = 0; i < difficultyButtons_.Length; ++i)
            {
                if (i + 1 == PlayerPrefs.GetInt("LevelDiff"))
                {
                    difficultyButtons_[i].GetComponent<Image>().color = Color.yellow;
                }
                else
                {
                    difficultyButtons_[i].GetComponent<Image>().color = Color.white;
                }
            }
        }
        else
        {
            SetDifficulty(2);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
