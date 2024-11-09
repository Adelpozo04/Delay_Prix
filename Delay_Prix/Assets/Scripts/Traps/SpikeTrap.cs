using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    #region parameters

    [SerializeField] private float spikeTimeDuration_;

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

        myAnim_.SetTrigger("ActivateSpikes");

        Invoke("TrapDesactivate", spikeTimeDuration_);

        base.TrapActivate();
    }

    public override void TrapDesactivate()
    {
        myAnim_.SetTrigger("DeactivateSpikes");

        base.TrapDesactivate();
    }
}
