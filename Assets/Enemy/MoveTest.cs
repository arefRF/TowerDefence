using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{

    [SerializeField]
    public NodePoint destination_;
    [SerializeField]
    private float max_distance_;

    public Delegate_NoArgument OnDestinationchanged;

    private EnemyBase enemy_base_;
    // Start is called before the first frame update
    void Start()
    {
        enemy_base_ = GetComponent<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceTo(destination_.transform.position) <= 0)
        {
            destination_ = destination_.parent_;
            if(destination_ == null)
            {
                enemy_base_.Release();
            }
            else
                OnDestinationchanged?.Invoke();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination_.transform.position, max_distance_);
        }
    }

    private int DistanceTo(Vector3 vector)
    {
        return (int)Vector3.Distance(transform.position, vector);
    }
}