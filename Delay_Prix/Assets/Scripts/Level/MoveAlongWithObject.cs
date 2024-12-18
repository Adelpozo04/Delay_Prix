using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongWithObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collidion");

        if(other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }

    }

}
