using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!GetComponent<PlayerMovement>().isMoving())
        {
            GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            GetComponent<CharacterController>().enabled = true;
        }

    }
}
