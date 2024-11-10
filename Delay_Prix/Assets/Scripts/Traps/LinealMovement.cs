using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealMovement : MonoBehaviour
{

    #region parameters

    [SerializeField] private float speed_;

    #endregion

    private Rigidbody myRB_;

    // Start is called before the first frame update
    void Start()
    {
        myRB_= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        myRB_.MovePosition(transform.position + transform.rotation * new Vector3(0, 0, 1) * speed_ * Time.deltaTime);

    }
}
