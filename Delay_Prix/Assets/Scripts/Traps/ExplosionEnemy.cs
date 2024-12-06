using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class ExplosionEnemy : MonoBehaviour
{

    #region parameters

    [SerializeField] private float distanceToExplote_;

    #endregion

    #region properties

    private ViewPlayer myVP_;
    private DestroyAfterTime myDAT_;
    private Animator myAnim_;
    private AnimatorStateInfo infoAnim_;
    private EnemyAIPatrol myEP_;
    private bool exploted_ = false;
    private bool finishExplosion_ = false;

    #endregion

    #region references

    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject explosiveWave_;
    [SerializeField] private GameObject particles_;

    #endregion

    public void StartExplotion()
    {
        myAnim_.SetBool("walk", false);
        myAnim_.SetTrigger("attack");
        particles_.SetActive(true);
        particles_.GetComponent<ParticleSystem>().Play();   
        myEP_.enabled= false;
        exploted_ = true;
        
    }

    public void Explote()
    {
        GetComponent<AudioSource>().Play();
        myDAT_.enabled = true;
        explosiveWave_.SetActive(true);
        finishExplosion_= true;
    }

    // Start is called before the first frame update
    void Start()
    {
        myVP_= GetComponent<ViewPlayer>();
        myDAT_= GetComponent<DestroyAfterTime>();
        myAnim_= GetComponent<Animator>();
        infoAnim_ = myAnim_.GetCurrentAnimatorStateInfo(0);
        myEP_ = GetComponent<EnemyAIPatrol>();
    }

    private void Update()
    {
        infoAnim_ = myAnim_.GetCurrentAnimatorStateInfo(0);

        if (myVP_.PlayerDetected() && Vector3.Distance(transform.position, player_.transform.position) < distanceToExplote_)
        {
            StartExplotion();
        }

        if (infoAnim_.IsName("attack01") && exploted_)
        {
            if (infoAnim_.normalizedTime % 1.0 >= 0.8)
            {
                if (!finishExplosion_)
                {
                    Explote();
                }
                
            }
        }
    }

}
