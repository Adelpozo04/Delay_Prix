using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{

    #region properties

    [SerializeField] private Animator myAni_;

    private CharacterController myCC_;

    private CameraMovement myCameraMovement_;

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

    //Initiates the coroutine of the roll and makes the collider smaller. Also change the states of some bools that are used on the update.
    public void Roll(InputAction.CallbackContext context)
    {

        if (grounded_ && context.started && canRoll_)
        {

            canRoll_ = false;

            rolling_ = true;

            myCC_.height = heightRolling_;

            myCC_.center.Set(myCC_.center.x, yCenterRolling_, myCC_.center.z);

            startTimeRoll_ = Time.time;

            myCameraMovement_.TurnModelToCamera();

            StartCoroutine(RollStart());

        }

    }

    public bool isRolling()
    {
        return rolling_;
    }

    // Start is called before the first frame update
    void Start()
    {

        myCC_ = GetComponent<CharacterController>();
        myCameraMovement_= GetComponent<CameraMovement>();

        originalHeight_ = myCC_.height;
        originalY_ = myCC_.center.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        grounded_ = (Physics.Raycast(transform.position, Vector3.down * (myCC_.height / 1.5f), LayerMask.NameToLayer("Ground")));

        //Debug.DrawRay(transform.position, Vector3.down * myCC_.height, Color.red);

    }

    void Update()
    {
        //Manages the cooldown of the roll
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

        //Probar a cambiar esto para que se vuelva a los valores natuirales al acabar una animacion
        //Manage the change of the collider during the roll so it can return to normal when finish
        if (rolling_)
        {
            if(startTimeRoll_ + rollTime_ < Time.time)
            {

                myCC_.center.Set(myCC_.center.x, originalY_, myCC_.center.z);
                myCC_.height = originalHeight_;
                
                rolling_ = false;
            }
        }

        myAni_.SetBool("Rolling", rolling_);

    }

    //Corutine which moves the player in the roll direction until the roll time is over
    IEnumerator RollStart()
    {

        while(startTimeRoll_ + rollTime_ > Time.time)
        {

            myCC_.Move( Vector3.Normalize(gameObject.GetComponent<PlayerMovement>().GetDir()) * rollForce_ * Time.deltaTime);

            yield return null;

        }

        
    }
}
