using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapCreator : MonoBehaviour
{
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

    private void Start()
    {
        for (int i = 0; i <x_count_; i++)
        {
            for (int j = 0; j < z_count_; j++)
            {
                var pos = start_pos_ + new Vector3(i * x_distance_ + (j % 2) * (x_distance_ / 2), 0, j * z_distance_);
                Instantiate(hex_, pos, Quaternion.identity, transform);
            }
        }
    }
}
