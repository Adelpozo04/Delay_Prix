using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalComponent : MonoBehaviour
{

    [SerializeField] private int sceneToLoad_ = 0;

    //Finish the match when the player touch it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {  

            GameManager.Instance.FinishMatch(true, sceneToLoad_);

        }
    }

}
