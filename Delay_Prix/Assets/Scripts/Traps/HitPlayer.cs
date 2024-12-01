using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class HitPlayer : MonoBehaviour
{

    #region parameters

    [SerializeField] private float forceHit_;

    #endregion

    #region properties

    [SerializeField] private Transform hitMiddle_;

    private bool noHit_;

    #endregion

    public void EffetActivation(bool activate)
    {
        noHit_ = activate;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!noHit_)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !collision.gameObject.GetComponent<RagDollState>().getRagDoll())
            {

                Debug.Log("Hammer Collision");

                collision.gameObject.GetComponent<RagDollState>().EnableRagDoll();

                Vector3 vectorHit = collision.gameObject.transform.position - hitMiddle_.position;

                GameObject playerBody_ = collision.transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).gameObject;

                playerBody_.GetComponent<Rigidbody>().AddForceAtPosition(vectorHit * forceHit_, playerBody_.gameObject.transform.position, ForceMode.Impulse);

            }
        }
        
    }

}
