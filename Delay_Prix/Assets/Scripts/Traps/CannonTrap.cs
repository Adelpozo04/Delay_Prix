using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrap : Trap
{

    #region parameters

    [SerializeField] private float instantiateDistance_;
    [SerializeField] private float force_;

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

        direction.y += 5;

        GameObject bullet = Instantiate(bullets_, direction, transform.rotation);

        //bullet.GetComponent<Rigidbody>().AddForce(transform.rotation * new Vector3(0, 0, 1) * force_ * Time.deltaTime);

        particles_.Play();

        base.TrapActivate();
    }
}
