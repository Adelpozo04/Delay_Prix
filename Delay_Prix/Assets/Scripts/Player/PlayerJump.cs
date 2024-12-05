using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerJump : MonoBehaviour
{

    #region properties

    private CharacterController myCC_;

    private PlayerMovement myPM_;

    [SerializeField] private Animator myAni_;

    private Vector3 move;

    private bool grounded;

    #endregion

    #region parameters

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private float actualVelocity;

    #endregion

    //Apply a specified gravity to the velocity so the vector move can reduce its force up until it reach 0 

    private void ApplyGravity()
    {

        if (isJumping())
        {
            move = myPM_.getDir() * 2;
        }
        else
        {
            move = Vector3.zero;
        }

        move.y = actualVelocity;

        if (grounded && move.y < 0)
        {
            actualVelocity = 0;
        }
        else
        {
            actualVelocity -= gravity * Time.deltaTime;
        }


    }

    //Apply the jumpforce to the actualvelocity, which will be apply then in the method ApplyGravity to the vector move
    //which is used to make the movement by using the character controller

    public void Jump(InputAction.CallbackContext context)
    {

        if (grounded && context.started)
        {
            actualVelocity = jumpForce;       
        }

    }

    public bool isJumping()
    {

        return !grounded && actualVelocity > 0;

    } 

    // Start is called before the first frame update
    void Start()
    {
        
        myCC_= GetComponent<CharacterController>();
        myPM_= GetComponent<PlayerMovement>();

    }

    //We use a raycast down to check if the player is touching what is considered as ground
    void FixedUpdate()
    {

        ApplyGravity();

        myCC_.Move(move * Time.deltaTime);

        grounded = (Physics.Raycast(transform.position, Vector3.down * (myCC_.height / 1.5f), LayerMask.NameToLayer("Ground")));

        //Debug.DrawRay(transform.position, Vector3.down * (myCC_.height / 1.5f), Color.red);

        myAni_.SetBool("OnGround", grounded);


    }
}
