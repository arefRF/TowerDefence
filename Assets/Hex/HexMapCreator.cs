using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapCreator : MonoBehaviour
{

    public GameObject g;
    [SerializeField]
    private GameObject hex_;

    [SerializeField]
    private float x_distance_;
    [SerializeField]
    private float z_distance_;
    [SerializeField]
    private int x_count_,z_count_;
    [SerializeField]
    private Vector3 start_pos_;

    private List<GameObject> hex_list = new List<GameObject>();

    private void Start()
    {
        
    }

    public void GenerateMap()
    {
        Clear();
        for (int i = 0; i <x_count_; i++)
        {
            for (int j = 0; j < z_count_; j++)
            {
                var pos = start_pos_ + new Vector3(i * x_distance_ + (j % 2) * (x_distance_ / 2), 0, j * z_distance_);
                hex_list.Add(Instantiate(hex_, pos, Quaternion.identity, transform));            }
        }
    }

    public void Clear()
    {
        for(int i=0; i<hex_list.Count; i++)
        {
            DestroyImmediate(hex_list[i]);
        }
        hex_list.Clear();
    }
}
