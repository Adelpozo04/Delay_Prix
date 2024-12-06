using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivation : MonoBehaviour
{

    [SerializeField] private FollowRoute[] platformsToActivate;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            for (int i = 0; i < platformsToActivate.Length; i++)
            {
                GetComponent<AudioSource>().Play();

                platformsToActivate[i].enabled = true;
            }

        }
    }

}
