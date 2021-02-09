using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    private TileType type_;

    public Vector2Int position_;
}

public enum TileType
{
    Road, Crystal, Ground, Goal
}
