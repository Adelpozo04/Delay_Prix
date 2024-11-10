using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrap : Trap
{

    #region parameters

    [SerializeField] private float instantiateDistance_;

    #endregion

    #region references

    [SerializeField] private GameObject bullets_;
    [SerializeField] private ParticleSystem particles_;

    #endregion

    #region properties

    private Animator myAnim_;

    #endregion


    protected override void Start()
    {
        myAnim_ = GetComponent<Animator>();

        base.Start();
    }

    public override void TrapActivate()
    {

        myAnim_.SetTrigger("ActivateTrap");

        Instantiate(bullets_, transform.position + (transform.rotation * new Vector3(0, 0, 1) * instantiateDistance_), transform.rotation);

        particles_.Play();

        base.TrapActivate();
    }
}
