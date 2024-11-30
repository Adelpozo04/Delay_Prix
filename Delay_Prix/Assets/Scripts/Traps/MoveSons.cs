using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSons : MonoBehaviour
{

    [SerializeField] private GameObject [] affectedSons_;

    private Vector3[] originalSonsPos_; 

    public void MoveSonsToMe()
    {

    }

    public void ResetSonsPos()
    {

        for (int i = 0; i < affectedSons_.Length; ++i)
        {
            affectedSons_[i].transform.position = originalSonsPos_[i];
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        originalSonsPos_ = new Vector3[affectedSons_.Length];

        for (int i = 0; i < affectedSons_.Length; ++i)
        {
            originalSonsPos_[i] = affectedSons_[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
