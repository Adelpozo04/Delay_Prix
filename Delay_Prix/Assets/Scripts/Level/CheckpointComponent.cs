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

    //When the player enters in the zone the current checkpoint changes to this one. Also there is a bool which stops the player of taking the same checkpoint several times.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && !checkpointTaken_)
        {

            checkpointTaken_ = true;

            Vector3 pos = transform.position + new Vector3(0, spawnOffset_, 0);

            GameManager.Instance.SetCurrentCheckpoint(pos);

        }
    }

}
