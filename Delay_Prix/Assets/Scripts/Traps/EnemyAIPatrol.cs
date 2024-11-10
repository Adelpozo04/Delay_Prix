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
    private bool walkPointSet_ = false;

    #endregion

    #region references

    private GameObject player_;

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
            Debug.Log("Move to destination");

            myNMA_.SetDestination(destPoint_);
        }

        Debug.Log(Vector3.Distance(transform.position, destPoint_) + " < " + arriveRange_);
        

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
            Debug.Log("Change destination");

            walkPointSet_ = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        myNMA_ = GetComponent<NavMeshAgent>();
        myAnim_= GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Patrol();

        myAnim_.SetBool("walk", walkPointSet_);

    }
}
