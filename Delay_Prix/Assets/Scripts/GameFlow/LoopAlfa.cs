using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopAlfa : MonoBehaviour
{

    #region properties

    private Image alfa_;

    private bool reducing_;

    private int loops_ = 0;

    private Color auxColor_;

    #endregion

    #region parameters

    [SerializeField, Range(0, 1)] private float effectSpeed_;

    #endregion

    public void StartEffect(int numLoops, bool startDark)
    {
        loops_ = numLoops;

        if (startDark)
        {
            auxColor_ = alfa_.color;
            auxColor_.a = 1;
            alfa_.color = auxColor_;      
        }

        reducing_ = startDark;

    }

    // Start is called before the first frame update
    void Start()
    {
        alfa_= GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
     
        if (loops_ != 0)
        {
            if (reducing_)
            {
                auxColor_ = alfa_.color;
                auxColor_.a -= effectSpeed_ * Time.deltaTime;
                alfa_.color = auxColor_;

                if(alfa_.color.a <= 0)
                {
                    reducing_ = !reducing_;
                    loops_--;
                }
                
            }
            else
            {
                auxColor_ = alfa_.color;
                auxColor_.a += effectSpeed_ * Time.deltaTime;
                alfa_.color = auxColor_;

                Debug.Log(alfa_.color.a);

                if (alfa_.color.a >= 1)
                {
                    reducing_ = !reducing_;   
                }
            }   

        } 

    }
}
