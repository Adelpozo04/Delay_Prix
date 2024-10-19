using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject player_;
    [SerializeField] private float speed_ = 0;
    [SerializeField] private float separation_ = 5;
    [SerializeField] private float cameraHigh_ = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float interpolation = speed_ * Time.deltaTime;

        Vector3 pos = transform.position;

        Vector3 behindTarget = player_.transform.position - separation_ * player_.transform.forward;


        //pos.x = Mathf.Lerp(transform.position.x, behindTarget.x, interpolation);
        pos.z = Mathf.Lerp(transform.position.z, behindTarget.z, interpolation);
        pos.y = Mathf.Lerp(transform.position.y, behindTarget.y + cameraHigh_, interpolation);


        transform.position = pos;

        transform.LookAt(player_.transform.position);

    }

}
