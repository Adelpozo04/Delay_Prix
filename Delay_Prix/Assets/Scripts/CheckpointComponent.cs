using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointComponent : MonoBehaviour
{

    #region parameters

    [SerializeField] private float spawnOffset_;

    #endregion

    #region properties

    private bool checkpointTaken_ = false;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && !checkpointTaken_)
        {

            checkpointTaken_ = true;

            Vector3 pos = transform.position + new Vector3(0, spawnOffset_, 0);

            GameManager.Instance.SetCurrentCheckpoint(pos);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
