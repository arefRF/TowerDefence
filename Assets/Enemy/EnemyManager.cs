using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager sSingletone;


    private List<EnemyBase> enemies_;
    void Start() 
    {
        if(sSingletone != null)
        Debug.LogError("there are more than one " + gameObject, gameObject);
        sSingletone = this;

        enemies_ = new List<EnemyBase>();
    }

    public void AddEnemyToList(EnemyBase enemy)
    {
        enemies_.Add(enemy);
    }

    public void RemoveEnemyFromList(EnemyBase enemy)
    {
        if(enemies_.Contains(enemy))
            enemies_.Remove(enemy);
        else
            Debug.LogError("enemy not int the list! enemy: " + enemy);
    }

    public EnemyBase GetRandomEnemy()
    {
        if(enemies_.Count == 0)
            return null;
        int rand_num = Random.Range(0, enemies_.Count);
        return enemies_[rand_num];
    }

    public EnemyBase GetNearestEnemy(Vector3 position)
    {
        EnemyBase enemy = null;
        float distance = int.MaxValue;
        for(int i=0; i<enemies_.Count; i++)
        {
            var temp = Vector3.Distance(position, enemies_[i].transform.position);
            if(distance > temp)
            {
                distance = temp;
                enemy = enemies_[i];
            }
        }
        return enemy;
    }

    public EnemyBase GetFurthestEnemy(Vector3 position)
    {
        EnemyBase enemy = null;
        float distance = 0;
        for(int i=0; i<enemies_.Count; i++)
        {
            var temp = Vector3.Distance(position, enemies_[i].transform.position);
            if(distance < temp)
            {
                distance = temp;
                enemy = enemies_[i];
            }
        }
        return enemy;
    }
}
