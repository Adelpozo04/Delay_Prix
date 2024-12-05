using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    #region references

    [SerializeField] Camera myCam_;

    [SerializeField] private Animator myAni_;

    [SerializeField] private GameObject model_;

    #endregion

    #region properties

    private CharacterController myCC_;   

    private Vector3 dir_;

    private bool running_ = false;

    private CameraMovement myCamMov_;

    #endregion

    #region parameters

    [SerializeField] private float speed_ = 5;

    [SerializeField] private float acceleration_ = 5;

    #endregion

    //Updates the direction where the player is moving
    public void ChangeDir(InputAction.CallbackContext context)
    {
        myCC_.enabled = true;
        dir_ = context.ReadValue<Vector3>();
    }

    //Detects if the player is pressing the button of running to enter in that state and stop it when he stop pressing it
    public void Running(InputAction.CallbackContext context)
    {

        if (context.phase == InputActionPhase.Started)
        {
            running_ = true;
        }
        else if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled)
        {
            running_ = false;
        }

    }

    //Returns the direction of movement of the player
    public Vector3 GetDir()
    {
        float camRot = myCam_.transform.eulerAngles.y;

        return Quaternion.Euler(0, camRot, 0) * dir_;
    }

    public bool isMoving()
    {

        return dir_ != Vector3.zero;

    }

    public Vector3 getDir()
    {
        return Quaternion.Euler(0, myCam_.transform.eulerAngles.y, 0) * dir_;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        myCC_= GetComponent<CharacterController>();
        myCamMov_= GetComponent<CameraMovement>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float camRot = myCam_.transform.eulerAngles.y;

        Vector3 localXZ = Quaternion.Euler(0, camRot, 0) * dir_;

        //Whenever the player is moving its model must be facing where the camera faces
        if (dir_ != Vector3.zero)
        {
            myCamMov_.TurnModelToCamera();
            
        }

        if (running_)
        {
            myCC_.SimpleMove((speed_ + acceleration_) * localXZ);
        }
        else
        {
            myCC_.SimpleMove(speed_ * localXZ);
        }

        myAni_.SetFloat("VelocityZ", dir_.z);
        myAni_.SetFloat("VelocityX", dir_.x);
        myAni_.SetBool("Running", running_);

    }
}
