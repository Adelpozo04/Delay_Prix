using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrap : Trap
{

    #region parameters

    [SerializeField] private float instantiateDistance_;
    [SerializeField] private float bulletHeight_ = 3;

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

        Vector3 direction = transform.position + (transform.rotation * new Vector3(0, 0, 1) * instantiateDistance_);

        direction.y += bulletHeight_;

        GameObject bullet = Instantiate(bullets_, direction, transform.rotation);

        particles_.Play();

        base.TrapActivate();
    }
}
