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


    public void MoveCamera(InputAction.CallbackContext context)
    {

        dir_ = context.ReadValue<Vector3>();

    }

    public void TurnModelToCamera()
    {
        model_.transform.right = mainCam_.transform.right;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mainCam_.transform.RotateAround(model_.transform.position, dir_, camSpeed_ * Time.deltaTime);

    }
}
