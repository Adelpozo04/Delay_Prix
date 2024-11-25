using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScoreComponent : MonoBehaviour
{
    #region references

    [SerializeField] private Image fill_;

    #endregion



    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        fill_.fillAmount = (float)PlayerPrefs.GetInt("TestScore") / (float)PlayerPrefs.GetInt(PlayerPrefs.GetString("LastScene"));

    }
}
