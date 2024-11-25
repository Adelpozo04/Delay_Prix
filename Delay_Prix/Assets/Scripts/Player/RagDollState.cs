using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RagDollState : MonoBehaviour
{

    #region properties

    private Rigidbody[] ragdollRigidBodies_;
    private CharacterJoint[] joints_;
    private Collider[] colliders_;
    private CharacterController myCC_;
    private PlayerInput myPI_;
    private bool ragdolled_ = false;
    private float elapsedTime_ = 0;

    #endregion

    #region references

    [SerializeField] private Animator myAnim_;

    [SerializeField] private GameObject model_;

    #endregion

    #region parameters

    [SerializeField] private float duration_ = 5;

    #endregion


    public bool getRagDoll()
    {
        return ragdolled_;
    }

    public void DisableRagDoll()
    {

        transform.position = model_.transform.position + Vector3.up * 2;

        myCC_.enabled = true;
        myAnim_.enabled = true;
        myPI_.enabled = true;
        ragdolled_ = false;

        foreach (var joint in joints_)
        {
            joint.enableCollision = false;
        }

        foreach (var collider in colliders_)
        {
            collider.enabled = false;
        }

        foreach (var rigidbody in ragdollRigidBodies_)
        {
            rigidbody.isKinematic = true;
            rigidbody.detectCollisions = false;
        }
    }

    public void EnableRagDoll()
    {

        Debug.Log("Active Ragdoll");

        myCC_.enabled = false;
        myAnim_.enabled = false;
        myPI_.enabled = false;
        ragdolled_ = true;

        foreach (var joint in joints_)
        {
            joint.enableCollision = true;
        }

        foreach (var collider in colliders_)
        {
            collider.enabled = true;
        }

        foreach (var rigidbody in ragdollRigidBodies_)
        {         
            rigidbody.isKinematic = false;
            rigidbody.detectCollisions = true;
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        ragdollRigidBodies_ = GetComponentsInChildren<Rigidbody>();
        joints_ = GetComponentsInChildren<CharacterJoint>();
        colliders_ = GetComponentsInChildren<Collider>();
        myCC_ = GetComponent<CharacterController>();
        myPI_ = GetComponent<PlayerInput>();

        DisableRagDoll();
    }

    // Update is called once per frame
    void Update()
    {
        if (ragdolled_)
        {

            if(elapsedTime_ > duration_)
            {
                DisableRagDoll();
                elapsedTime_ = 0;
            }
            else
            {
                elapsedTime_ += Time.deltaTime;
            }            

        }


    }
}
