using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private List<EnemyBaseChancePair> enemy_prefab_list_;
    [SerializeField]
    private GameObject enemy_parent_;
    [SerializeField]
    private List<TileBase> spawner_point_;
    [SerializeField]
    private float spawn_interval_;

    private float current_interval_;
    private List<NodePoint> spawner_node_;
    private int chance_sum_;
    void Start()
    {
        current_interval_ = spawn_interval_;
        spawner_node_ = new List<NodePoint>();
        for(int i=0; i<enemy_prefab_list_.Count; i++)
            chance_sum_ += enemy_prefab_list_[i].chance_;
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
        int rand = Random.Range(0, spawner_point_.Count);
        var go = Instantiate(GetRandomEnemy(), spawner_point_[rand].transform.position, spawner_point_[rand].transform.rotation, enemy_parent_.transform);
        go.GetComponent<MoveTest>().destination_ = spawner_node_[rand];
        EnemyManager.sSingleton.AddEnemyToList(go.GetComponent<EnemyBase>());
    }

    private GameObject GetRandomEnemy()
    {
        var rand = Random.Range(0, chance_sum_);
        int current_chance_sum = 0;
        for(int i=0; i<enemy_prefab_list_.Count; i++)
        {
            current_chance_sum += enemy_prefab_list_[i].chance_;
            if(rand < current_chance_sum)
                return enemy_prefab_list_[i].enemy_object_;
        }
        Debug.LogError("problem in chance in enemy spawn");
        return null;
    }
}

[System.Serializable]
public class EnemyBaseChancePair 
{
    public GameObject enemy_object_;
    public int chance_;
}
