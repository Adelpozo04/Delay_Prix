using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    #region parameters

    [SerializeField] private float time_ = 10;

    #endregion

    #region properties

    private float elapsedTime_ = 0;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(elapsedTime_ > time_)
        {
            Destroy(gameObject);
        }
        else
        {
            elapsedTime_ += Time.deltaTime;
        }

    }
}
