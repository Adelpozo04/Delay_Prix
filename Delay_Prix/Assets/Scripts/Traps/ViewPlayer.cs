using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlayer : MonoBehaviour
{

    #region parameters

    [SerializeField] private float radius_;

    [Range(0, 360)]
    [SerializeField] private float angle_;

    #endregion

    #region properties

    [SerializeField] private LayerMask playerLayer_, obstaclesLayer_;

    private bool seePlayer_;

    #endregion

    #region references

    #endregion

    private void CheckPlayer()
    {

        Collider[] detectedObj = Physics.OverlapSphere(transform.position, radius_, playerLayer_);

        if(detectedObj.Length > 0)
        {

            Transform target = detectedObj[0].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, dirToTarget) < angle_/2)
            {

                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstaclesLayer_))
                {
                    seePlayer_ = false;
                }
                else
                {

                    seePlayer_ = true;
                }

            }
            else
            {
                seePlayer_= false;
            }

        }
        else if(seePlayer_){
            seePlayer_= false;
        }

    }

    public bool PlayerDetected()
    {

        return seePlayer_;

    }

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {

        CheckPlayer();

    }
}
