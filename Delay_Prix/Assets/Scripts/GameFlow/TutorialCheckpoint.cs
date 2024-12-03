using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialCheckpoint : MonoBehaviour
{

    #region references

    [SerializeField] private TextMeshProUGUI instructionsText_;

    [SerializeField] private TextMeshProUGUI enterText_;

    [SerializeField] private GameObject player_;

    #endregion

    #region properties

    [SerializeField] private string [] text_;

    private bool playerArrive_ = false;

    private int textCounter_ = 0;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        
        if(!playerArrive_ && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            Debug.Log("Touch");

            player_.GetComponent<PlayerInput>().enabled = false;
            playerArrive_= true;
            enterText_.gameObject.SetActive(true);
            instructionsText_.text = text_[textCounter_];
            textCounter_++;

        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (playerArrive_ && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(playerArrive_ + " / " + textCounter_ + "<" + text_.Length);

            if(textCounter_ < text_.Length)
            {
                instructionsText_.text = text_[textCounter_];
                textCounter_++;
            }
            else
            {
                player_.GetComponent<PlayerInput>().enabled = true;
                instructionsText_.text = "";
                enterText_.gameObject.SetActive(false);
                this.enabled= false;
            }
        }

    }
}
