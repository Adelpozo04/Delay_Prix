using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{


    #region references

    [SerializeField] private Camera mainCam_;

    [SerializeField] private GameObject model_;

    #endregion

    #region parameters

    [SerializeField] private float camSpeed_ = 5;

    #endregion

    #region properties

    private Vector3 dir_;

    #endregion

    //Updates de direction where the camera must look at
    public void MoveCamera(InputAction.CallbackContext context)
    {

        dir_ = context.ReadValue<Vector3>();

    }

    //Turn the player model to face where the camera is facing
    public void TurnModelToCamera()
    {
        model_.transform.right = mainCam_.transform.right;
    }

    // Update is called once per frame
    void Update()
    {

        mainCam_.transform.RotateAround(model_.transform.position, dir_, camSpeed_ * Time.deltaTime);

    }
}
