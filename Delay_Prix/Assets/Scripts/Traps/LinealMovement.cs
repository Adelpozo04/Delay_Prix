using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealMovement : MonoBehaviour
{

    #region parameters

    [SerializeField] private float speed_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.rotation * new Vector3(0, 0, 1) * speed_ * Time.deltaTime;

    }
}
