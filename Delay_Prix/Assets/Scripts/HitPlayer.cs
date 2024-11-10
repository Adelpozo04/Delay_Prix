using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Debug.Log("Hammer Collision");
        hit.gameObject.GetComponent<RagDollState>().EnableRagDoll();

    }


}
