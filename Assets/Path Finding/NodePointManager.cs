using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFinding;

public class NodePointManager : MonoBehaviour
{
    public static NodePointManager sSingleton;
    [SerializeField]
    private NodePoint[] nodes_;
    [SerializeField]
    private NodePoint target_node_;

    private Graph graph_;
    void Awake()
    {
        sSingleton = this;
        CreateGraph();
    }

    private void CreateGraph()
    {
        var graph_nodes = new int[nodes_.Length];
        for (int i = 0; i < nodes_.Length; i++)
            graph_nodes[i] = nodes_[i].pNumber;
        var edges_ = new List<Vector3Int>();
        for (int i = 0; i < nodes_.Length; i++)
        {
            NodePoint np = nodes_[i];
            for (int j = 0; j < np.pPaths.Length; j++)
            {
                int distance = (int)Vector3.Distance(np.transform.position, np.pPaths[j].transform.position);
                edges_.Add(new Vector3Int(np.pNumber, np.pPaths[j].pNumber, distance));
            }
        }
        graph_ = Graph.CreateGraph(graph_nodes, edges_.ToArray());
        GraphTools.OperateBelmanFord(graph_, target_node_.pNumber, out graph_);

        for(int i=0; i<nodes_.Length; i++)
        {
            if (graph_.nodes_[i].parent_ == null)
                nodes_[i].parent_ = -1;
            else
                nodes_[i].parent_ = graph_.nodes_[i].parent_.pNumber;
        }
    }

    public NodePoint GetNextNode(NodePoint current_node)
    {
        if (graph_.nodes_[current_node.pNumber].parent_ == null)
            return null;
        return nodes_[graph_.nodes_[current_node.pNumber].parent_.pNumber];
    }
}
