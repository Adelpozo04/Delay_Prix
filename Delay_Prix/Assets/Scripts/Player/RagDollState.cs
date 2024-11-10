using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollState : MonoBehaviour
{

    private Rigidbody[] ragdollRigidBodies_;
    private CharacterController myCC_;
    [SerializeField]private Animator myAnim_;

    public void DisableRagDoll()
    {
        foreach (var rigidbody in ragdollRigidBodies_)
        {
            myCC_.enabled = true;
            myAnim_.enabled = true;
            rigidbody.isKinematic = true;
        }
    }

    public void EnableRagDoll()
    {

        foreach (var rigidbody in ragdollRigidBodies_)
        {
            myCC_.enabled = false;
            myAnim_.enabled = false;
            rigidbody.isKinematic = false;
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        ragdollRigidBodies_ = GetComponentsInChildren<Rigidbody>();
        myCC_ = GetComponent<CharacterController>();

        DisableRagDoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
