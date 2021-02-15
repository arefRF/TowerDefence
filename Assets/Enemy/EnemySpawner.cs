using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy_prefab_;
    [SerializeField]
    private GameObject enemy_parent_;
    [SerializeField]
    private TileBase spawner_point_;
    [SerializeField]
    private float spawn_interval_;

    private float current_interval_;
    private NodePoint spawner_node_;
    void Start()
    {
        current_interval_ = spawn_interval_;
        spawner_node_ = spawner_point_.GetComponent<NodePoint>();
    }

    // Update is called once per frame
    void Update()
    {
        current_interval_ -= Time.deltaTime;
        if(current_interval_ <= 0)
        {
            current_interval_ = spawn_interval_;
            var go = Instantiate(enemy_prefab_, spawner_point_.transform.position, spawner_point_.transform.rotation, enemy_parent_.transform).GetComponent<MoveTest>();
            go.destination_ = spawner_node_;
        }
    }
}
