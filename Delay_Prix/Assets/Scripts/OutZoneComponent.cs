using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZoneComponent : MonoBehaviour
{

    //Restart the player position when it touch it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            GameManager.Instance.RestartPlayer();

        }
    }

}
