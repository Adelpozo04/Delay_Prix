using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneComponent : MonoBehaviour
{

    private AudioSource sound_;

    //Is used to change the scene by pressing a button, which will call this method
    public void ChangeScene(int sceneIndex)
    {

        sound_.Play();

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
