using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class NodePoint : MonoBehaviour
{
    [SerializeField]
    public int number_;
    public int pNumber { get { return number_; } }

    [SerializeField]
    private NodePoint[] paths_;
    public NodePoint[] pPaths { get { return paths_; } }

    [SerializeField]
    public NodePoint parent_;
}
