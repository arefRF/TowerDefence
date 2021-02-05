using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class Graph
    {
        public List<GNode> nodes_;
        public List<GEdge> edge_list_;

        public static Graph CreateGraph(int[] node_numbers, Vector3Int[] edge_list) 
        {
            return new Graph(node_numbers, edge_list);
        }

        public static Graph CreateGraph(int[] node_numbers, Vector2Int[] edge_list, int default_weight)
        {
            Vector3Int[] edge_weight_list = new Vector3Int[edge_list.Length];
            for (int i = 0; i < edge_list.Length; i++)
            {
                edge_weight_list[i] = new Vector3Int(edge_list[i].x, edge_list[i].y, default_weight);
            }
            return new Graph(node_numbers, edge_weight_list);
        }

        private Graph()
        {
            nodes_ = new List<GNode>();
        }

        private Graph(int[] node_numbers, Vector3Int[] edge_list)
        {
            edge_list_ = new List<GEdge>();
            nodes_ = new List<GNode>();
            for (int i = 0; i < node_numbers.Length; i++)
                AddNode(new GNode(node_numbers[i]));
            for (int i = 0; i < node_numbers.Length; i++) 
            {
                for(int j=0; j < edge_list.Length; j++)
                {
                    GEdge edge = new GEdge(GetNode(edge_list[j].x), GetNode(edge_list[j].y), edge_list[j].z);
                    edge_list_.Add(edge);
                    nodes_[i].AddEdge(edge);
                }
            }
        }

       

        public void AddNode(GNode node)
        {
            nodes_.Add(node);
        }

        public GNode GetNode(int node_number)
        {
            for (int i = 0; i < nodes_.Count; i++)
                if (nodes_[i].pNumber == node_number)
                    return nodes_[i];
            Debug.LogError("Can not find node: " + node_number);
            return null;
        }
    }

    public class GNode 
    {
        private int number_;
        public int pNumber { get { return number_; } }

        private List<GEdge> edge_list_;
        public List<GEdge> pEdgeList { get { return edge_list_; } }

        public int distance_to_source_ = int.MaxValue;
        public bool is_traversed_ = false;
        public GNode parent_ = null;
        public GNode(int number, List<GEdge> edge_list = null)
        {
            number_ = number;
            edge_list_ = edge_list == null ? new List<GEdge>() : edge_list;
        }

        public void AddEdge(GEdge edge)
        {
            edge_list_.Add(edge);
        }

        public List<GNode> GetNeightborNodes()
        {
            List<GNode> neighbor_nodes_ = new List<GNode>();
            for(int i=0; i < edge_list_.Count; i++)
                neighbor_nodes_.Add(edge_list_[i].source_.number_ == number_ ? edge_list_[i].source_ : edge_list_[i].sink_);
            return neighbor_nodes_;
        }
    }

    public struct GEdge
    {
        public int weight_;
        public GNode source_, sink_;

        public GEdge(GNode source, GNode sink, int weight)
        {
            weight_ = weight;
            source_ = source;
            sink_ = sink;
        }
    }

}
