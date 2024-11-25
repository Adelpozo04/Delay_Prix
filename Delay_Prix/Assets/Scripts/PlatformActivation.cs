using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivation : MonoBehaviour
{

    [SerializeField] private FollowRoute[] platformsToActivate; 


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            for (int i = 0; i < platformsToActivate.Length; i++)
            {
                platformsToActivate[i].enabled = true;
            }

        }

    }


}