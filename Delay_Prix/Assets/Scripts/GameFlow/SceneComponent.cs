using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneComponent : MonoBehaviour
{

    private AudioSource sound_;

    [SerializeField] private bool restartScore_;

    //Is used to change the scene by pressing a button, which will call this method
    public void ChangeScene(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);

    }

    public void ExitGame()
    {

        sound_.Play();

        Application.Quit();

    }

    // Start is called before the first frame update
    void Start()
    {
        
        sound_= GetComponent<AudioSource>();

        if (restartScore_)
        {
            PlayerPrefs.SetInt("TestScore", 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
