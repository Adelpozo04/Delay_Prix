using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongWithObject : MonoBehaviour
{

    //In order to make a character controller object move smoothly along with the object, the movement of that object must be done in the fixedUpdate

    //Also there must be two collider, a normal collider and a trigger a little bit up the object where is going to stand.

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Move along");

        other.gameObject.GetComponent<CharacterController>().enabled = false;

        other.gameObject.transform.SetParent(transform);

    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("Do not move along");

        other.gameObject.GetComponent<CharacterController>().enabled = true;

        other.gameObject.transform.SetParent(null);

    }

}
