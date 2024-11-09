using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableComponent : MonoBehaviour
{

    #region parameters

    [SerializeField] private int collectablePoints_ = 5000;

    #endregion

    //Restart the player position when it touch it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            GameManager.Instance.AddScore(collectablePoints_);

            Destroy(gameObject);

        }
    }
}
