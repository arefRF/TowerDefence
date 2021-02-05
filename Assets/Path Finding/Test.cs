using PathFinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            DO();
    }

    public static void DO()
    {
        int[] nodes = new int[] { 0, 1, 2, 3, 4 };
        List<Vector3Int> edges = new List<Vector3Int>();
        edges.Add(new Vector3Int(0, 1, 2));
        edges.Add(new Vector3Int(1, 0, 2));
        edges.Add(new Vector3Int(0, 2, 3));
        edges.Add(new Vector3Int(2, 0, 3));
        edges.Add(new Vector3Int(1, 4, 4));
        edges.Add(new Vector3Int(4, 1, 4));
        edges.Add(new Vector3Int(0, 4, 5));
        edges.Add(new Vector3Int(4, 0, 5));
        edges.Add(new Vector3Int(1, 3, 13));
        edges.Add(new Vector3Int(3, 1, 13));
        edges.Add(new Vector3Int(2, 3, 1));
        edges.Add(new Vector3Int(3, 2, 1));
        edges.Add(new Vector3Int(3, 4, 2));
        edges.Add(new Vector3Int(4, 3, 2));
        int source = 0;

        Graph g = Graph.CreateGraph(nodes, edges.ToArray());

        GraphTools.OperateBelmanFord(g, source, out g);

        for(int i = 0; i < g.nodes_.Count; i++)
        {
            GNode node = g.nodes_[i];
            Debug.Log("Node : " + node.pNumber + "  parent: " + node.parent_ + "   distance: " + node.distance_to_source_);
            /*for(int j=0; j< node.pEdgeList.Count; j++)
            {
                GEdge edge = node.pEdgeList[j];
                Debug.Log(edge.source_.number_ + "  ,  " + edge.sink_.number_ + "   W: " + edge.weight_);
            }*/
        }

        for(int i=1; i<nodes.Length; i++)
        {
            Debug.Log(GraphTools.PrintPath(g, g.nodes_[0], g.nodes_[i]));
        }
    }

}
