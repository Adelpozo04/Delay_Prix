using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class HitPlayer : MonoBehaviour
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        //Debug.Log("Hammer Collision");
        hit.gameObject.GetComponent<RagDollState>().EnableRagDoll();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hammer Collision");

        collision.gameObject.GetComponent<RagDollState>().EnableRagDoll();

    }

}
