using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{

    #region properties

    [SerializeField] private Vector3 cameraOriginalPos_;

    #endregion

    #region references

    [SerializeField] private Camera mainCamera_;

    #endregion

    public void RestartCameraPos()
    {

        mainCamera_.transform.localPosition = cameraOriginalPos_;

    }

    public void SetNewPosition(Vector3 pos)
    {

        cameraOriginalPos_= pos;

    }

    // Start is called before the first frame update
    void Start()
    {
        
        RestartCameraPos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
