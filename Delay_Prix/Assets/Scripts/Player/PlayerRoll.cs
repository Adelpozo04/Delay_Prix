using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{

    #region properties

    private CharacterController myCC_;

    [SerializeField] private Animator myAni_;

    private float elapsedTime_ = 0;

    private bool canRoll_ = true;

    private bool rolling_ = false;

    private bool grounded_;

    #endregion

    #region parameters

    [SerializeField] private float rollForce_;

    [SerializeField] private float rollTime_;

    [SerializeField] private float cooldownTime_;

    [SerializeField] private float heightRolling_;

    [SerializeField] private float yCenterRolling_;

    private float originalHeight_;
    private float originalY_;

    private float startTimeRoll_;

    #endregion

    public void Roll(InputAction.CallbackContext context)
    {

        if (grounded_ && context.started && canRoll_)
        {
            //Flip the cam and model while rolling

            canRoll_ = false;

            rolling_ = true;

            myCC_.height = heightRolling_;

            myCC_.center.Set(myCC_.center.x, yCenterRolling_, myCC_.center.z);

            startTimeRoll_ = Time.time;

            myAni_.SetTrigger("Roll");

            StartCoroutine(RollStart());

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        myCC_ = GetComponent<CharacterController>();
        originalHeight_ = myCC_.height;
        originalY_ = myCC_.center.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        grounded_ = (Physics.Raycast(transform.position, Vector3.down * (myCC_.height / 1.5f), LayerMask.NameToLayer("Ground")));

        Debug.DrawRay(transform.position, Vector3.down * myCC_.height, Color.red);

    }

    void Update()
    {
        if (!canRoll_)
        {
            if (elapsedTime_ >= cooldownTime_)
            {
                canRoll_ = true;
                elapsedTime_ = 0;
            }
            else
            {
                elapsedTime_ += Time.deltaTime;
            }
        }

        if (rolling_)
        {
            if(startTimeRoll_ + rollTime_ < Time.time)
            {

                myCC_.center.Set(myCC_.center.x, originalY_, myCC_.center.z);
                myCC_.height = originalHeight_;
                
                rolling_ = false;
            }
        }
        
    }

    IEnumerator RollStart()
    {

        while(startTimeRoll_ + rollTime_ > Time.time)
        {

            Debug.Log("Roll");

            myCC_.Move( Vector3.Normalize(gameObject.GetComponent<PlayerMovement>().GetDir()) * rollForce_ * Time.deltaTime);

            yield return null;

        }

        
    }
}
