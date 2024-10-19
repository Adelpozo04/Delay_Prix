using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{

    #region properties

    private CharacterController myCC_;

    [SerializeField] private Animator myAni_;

    private Vector3 move;

    private bool grounded;

    #endregion

    #region parameters

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private float actualVelocity;

    #endregion

    public void Roll(InputAction.CallbackContext context)
    {

        if (grounded && context.started)
        {
            actualVelocity = jumpForce;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        myCC_ = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        myCC_.Move(move * Time.deltaTime);

        grounded = (Physics.Raycast(transform.position, Vector3.down * (myCC_.height / 1.5f), LayerMask.NameToLayer("Ground")));

        Debug.DrawRay(transform.position, Vector3.down * myCC_.height, Color.red);

        myAni_.SetBool("OnGround", grounded);


        //hacer un raycast hacia abajo para comprobar si se puede saltar


    }
}
