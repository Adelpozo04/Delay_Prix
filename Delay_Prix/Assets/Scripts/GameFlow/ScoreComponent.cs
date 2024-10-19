using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
