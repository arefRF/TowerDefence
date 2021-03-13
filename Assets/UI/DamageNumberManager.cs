using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberManager : MonoBehaviour
{
    [SerializeField]
    private GameObject damage_number_prefab_;
    
    public void CreateDamageNumber(Vector3 pos,int damage)
    {
        var damage_number = Instantiate(damage_number_prefab_, Camera.main.WorldToScreenPoint(pos), Quaternion.identity,transform).GetComponent<DamageNumber>();
        damage_number.SetText(damage);
    }
}
