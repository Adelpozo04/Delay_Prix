using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTween : MonoBehaviour
{

    #region parameters

    [SerializeField] private float rotationSpeed_;

    #endregion

    #region properties

    [SerializeField] private Vector3 rotAxis_;

    #endregion



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(transform.position, rotAxis_, rotationSpeed_);

    }
}
