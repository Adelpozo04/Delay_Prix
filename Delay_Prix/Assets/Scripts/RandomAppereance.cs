using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppereance : MonoBehaviour
{

    #region properties

    [SerializeField] private Transform [] randomLocations_;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

        int locationIndex = Random.Range(0, randomLocations_.Length);

        transform.position = randomLocations_[locationIndex].position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
