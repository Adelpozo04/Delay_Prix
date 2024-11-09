using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrap : Trap
{

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

        base.TrapActivate();
    }


}
