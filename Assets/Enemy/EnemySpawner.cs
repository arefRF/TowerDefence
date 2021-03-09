using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> enemy_prefab_list_;
    [SerializeField]
    private GameObject enemy_parent_;
    [SerializeField]
    private List<TileBase> spawner_point_;
    [SerializeField]
    private float spawn_interval_;

    private float current_interval_;
    private List<NodePoint> spawner_node_;
    void Start()
    {
        current_interval_ = spawn_interval_;
        spawner_node_ = new List<NodePoint>();
        for(int i=0; i<spawner_point_.Count; i++)
            spawner_node_.Add(spawner_point_[i].GetComponent<NodePoint>());
    }

    // Update is called once per frame
    void Update()
    {
        current_interval_ -= Time.deltaTime;
        if(current_interval_ <= 0)
        {
            current_interval_ = spawn_interval_;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var rand = Random.Range(0, spawner_point_.Count);
        var go = Instantiate(GetRandomEnemy(), spawner_point_[rand].transform.position, spawner_point_[rand].transform.rotation, enemy_parent_.transform);
        go.GetComponent<MoveTest>().destination_ = spawner_node_[rand];
        EnemyManager.sSingletone.AddEnemyToList(go.GetComponent<EnemyBase>());
    }

    private GameObject GetRandomEnemy()
    {
        var rand = Random.Range(0, enemy_prefab_list_.Count);
        return enemy_prefab_list_[rand];
    }
}
