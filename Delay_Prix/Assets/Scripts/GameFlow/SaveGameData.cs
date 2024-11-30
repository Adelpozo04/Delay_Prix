using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{

    #region properties

    [SerializeField] private string dataPath_;

    #endregion


    public void Save()
    {

        string[] muldata = new string[] { PlayerPrefs.GetInt("Level1").ToString(), PlayerPrefs.GetInt("Level2").ToString() };

        string dataToSave = string.Join("|", muldata);

        File.WriteAllText(Application.dataPath + dataPath_, dataToSave);
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
