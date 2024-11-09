using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    #region parameters

    [SerializeField] protected float minActivationTime_;
    [SerializeField] protected float maxActivationTime_;
    [SerializeField] protected float cooldownTime_;

    #endregion

    #region propertie

    protected bool trapActivate_;

    protected float elapsedTime_;

    protected float waitTime_;

    #endregion

    public virtual void TrapActivate()
    {
        trapActivate_ = false;
    }

    public virtual void TrapDesactivate()
    {

    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (trapActivate_)
        {

            if(elapsedTime_> waitTime_)
            {
                TrapActivate();
                elapsedTime_ = 0;
            }
            else
            {
                elapsedTime_ += Time.deltaTime;
            }

        }
        else
        {

            if(elapsedTime_ > cooldownTime_)
            {
                trapActivate_ = true;
                elapsedTime_ = 0;
            }
            else
            {
                elapsedTime_ += Time.deltaTime;
            }

        }

    }
}
