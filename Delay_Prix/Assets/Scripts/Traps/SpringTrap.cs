using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTrap : Trap
{
    #region parameters

    [SerializeField] private float springTimeDuration_;

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

        Invoke("TrapDesactivate", springTimeDuration_);

        base.TrapActivate();
    }

    public override void TrapDesactivate()
    {
        myAnim_.SetTrigger("DesactivateTrap");

        base.TrapDesactivate();
    }
}
