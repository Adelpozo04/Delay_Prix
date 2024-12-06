using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("RagDoll"))
        {

            GetComponent<AudioSource>().Play();
            GameManager.Instance.RestartPlayer();

        }

    }

}
