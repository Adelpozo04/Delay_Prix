using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowRoute : MonoBehaviour
{

    enum Behaviour
    {

        FollowOrder,
        FollowInverse,
        Random

    }

    #region references

    [SerializeField] private Transform[] routePoints_;

    #endregion


    #region properties

    [SerializeField] private Behaviour behaviour_;

    private NavMeshAgent myNavMesh_;

    #endregion

    //Create parameter to specify the first route point

    #region parameters

    [SerializeField] private float distance = 2;

    private int targetIndex_ = 0;

    #endregion

    //Change the index of the new target depending on the behaviour choosen, right now the only behaviour tested is the FollowOrder
    public void ChangeTarget()
    {

        switch (behaviour_)
        {
            case Behaviour.FollowOrder:

                targetIndex_ = (targetIndex_ + 1) % routePoints_.Length;

                break;
            case Behaviour.FollowInverse:

                targetIndex_ = targetIndex_ - 1;

                if (targetIndex_ < 0) targetIndex_ = routePoints_.Length - 1;

                break;
            case Behaviour.Random:

                int index = targetIndex_;
                    
                while(index != targetIndex_)
                {

                    index = Random.Range(0, routePoints_.Length);

                }

                targetIndex_ = index;

                break;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        myNavMesh_= GetComponent<NavMeshAgent>();

        myNavMesh_.updateRotation = false;

    }

    //Change the target when it is close enought to the current target
    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, routePoints_[targetIndex_].transform.position) <= distance)
        {

            ChangeTarget();

        }

        myNavMesh_.destination = routePoints_[targetIndex_].position;

    }
}
