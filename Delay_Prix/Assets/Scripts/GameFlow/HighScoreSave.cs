using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSave : MonoBehaviour
{

    #region references

    [SerializeField] private SaveGameData saveGameData_;

    #endregion


    // Start is called before the first frame update
    void Start()
    {

        if (!PlayerPrefs.HasKey(PlayerPrefs.GetString("LastScene")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("LastScene"), PlayerPrefs.GetInt("TestScore"));
        }
        else
        {
            if(PlayerPrefs.GetInt("TestScore") > PlayerPrefs.GetInt(PlayerPrefs.GetString("LastScene")))
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("LastScene"), PlayerPrefs.GetInt("TestScore"));
            }
        }

        saveGameData_.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
