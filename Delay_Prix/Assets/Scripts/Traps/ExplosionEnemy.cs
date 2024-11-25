using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : MonoBehaviour
{

    #region parameters

    [SerializeField] private float distanceToExplote_;

    #endregion

    #region properties

    private ViewPlayer myVP_;
    private DestroyAfterTime myDAT_;
    private Animator myAnim_;
    private EnemyAIPatrol myEP_;

    #endregion

    #region references

    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject explosiveWave_;
    [SerializeField] private GameObject particles_;

    #endregion

    public void Explote()
    {
        myAnim_.SetBool("walk", false);
        myAnim_.SetTrigger("attack");
        particles_.SetActive(true);
        particles_.GetComponent<ParticleSystem>().Play();   
        myEP_.enabled= false;
        myDAT_.enabled = true;
        explosiveWave_.SetActive(true);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        myVP_= GetComponent<ViewPlayer>();
        myDAT_= GetComponent<DestroyAfterTime>();
        myAnim_= GetComponent<Animator>();
        myEP_= GetComponent<EnemyAIPatrol>();
    }

    private void Update()
    {

        if (myVP_.PlayerDetected() && Vector3.Distance(transform.position, player_.transform.position) < distanceToExplote_)
        {   
            Explote();
        }
    }

}
