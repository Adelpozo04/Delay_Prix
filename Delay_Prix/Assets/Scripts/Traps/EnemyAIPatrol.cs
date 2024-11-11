using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIPatrol : MonoBehaviour
{
    #region properties

    [SerializeField] private LayerMask groundLayer_, playerLayer_;

    private NavMeshAgent myNMA_;
    private Animator myAnim_;
    private Vector3 destPoint_;
    private ViewPlayer myVP_;
    private bool walkPointSet_ = false;

    #endregion

    #region references

    [SerializeField] private GameObject player_;

    #endregion

    #region parameters

    [SerializeField] private float rangePatrol_;
    [SerializeField] private float arriveRange_;

    #endregion

    private void Patrol()
    {
        if (!walkPointSet_)
        {
            SelectRandomDestination();
        }
        {
            myNMA_.SetDestination(destPoint_);
        }
        

        if (Vector3.Distance(transform.position, destPoint_) < arriveRange_)
        {
            walkPointSet_ = false;
        }
    }

    private void SelectRandomDestination()
    {

        float z = Random.Range(-rangePatrol_, rangePatrol_);
        float x = Random.Range(-rangePatrol_, rangePatrol_);

        destPoint_ = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint_, Vector3.down, 100, groundLayer_))
        {

            walkPointSet_ = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        myNMA_ = GetComponent<NavMeshAgent>();
        myAnim_= GetComponent<Animator>();
        myVP_ = GetComponent<ViewPlayer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (myVP_.PlayerDetected())
        {
            myNMA_.SetDestination(player_.transform.position);
            myAnim_.SetBool("walk", true);
        }
        else
        {
            Patrol();
            myAnim_.SetBool("walk", walkPointSet_);
        }
        

        

    }
}
