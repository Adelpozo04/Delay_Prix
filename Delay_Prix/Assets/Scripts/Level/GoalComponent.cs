using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class GoalComponent : MonoBehaviour
{

    [SerializeField] private int sceneToLoad_ = 0;

    //Finish the match when the player touch it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(waitForSound());

        }
    }

    IEnumerator waitForSound()
    {
        //Wait Until Sound has finished playing
        while (GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }

        GameManager.Instance.FinishMatch(true, sceneToLoad_);
    }

}
