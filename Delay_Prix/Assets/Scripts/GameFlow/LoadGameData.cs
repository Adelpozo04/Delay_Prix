using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{

    #region properties

    [SerializeField] private string dataPath_;

    #endregion

    private void Load()
    {

        string loadData = File.ReadAllText(Application.dataPath + dataPath_);
        string[] multidataloaded = loadData.Split('|');
        PlayerPrefs.SetInt("Level1", int.Parse(multidataloaded[0]));
        PlayerPrefs.SetInt("Level2", int.Parse(multidataloaded[1]));
        PlayerPrefs.SetInt("Level3", int.Parse(multidataloaded[2]));

    }

    // Start is called before the first frame update
    void Awake()
    {

        Load();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
