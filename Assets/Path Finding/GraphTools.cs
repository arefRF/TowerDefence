using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class GraphTools
    {
        public static bool OperateBelmanFord(Graph graph, int source, out Graph output)
        {
            for(int i=0; i < graph.nodes_.Count; i++)
            {
                if (graph.nodes_[i].pNumber == source)
                {
                    graph.nodes_[i].distance_to_source_ = 0;
                    break;
                }
            }


            for (int i = 0; i < graph.nodes_.Count - 1; i++)
            {
                foreach (GEdge edge in graph.edge_list_)
                {
                    Relax(edge.source_, edge.sink_, edge.weight_);
                }
            }
            //Checking if path exist or not to all vertices from source
            foreach (GEdge edge in graph.edge_list_)
            {
                if (edge.sink_.distance_to_source_ > edge.source_.distance_to_source_ + edge.weight_)
                {
                    output = graph;
                    return false;
                }
            }
            output = graph;
            return true;

        }
        public static string PrintPath(Graph g, GNode u, GNode v)
        {
            string output = "";
            if (v.pNumber != u.pNumber)
            {
                PrintPath(g, u, v.parent_);
                output += "Vertax " + v.pNumber + " weight: " + v.distance_to_source_ + "\n";
            }
            else
                output += "Vertax " + v.pNumber + " weight: " + v.distance_to_source_ + "\n";
            return output;
        }

        /*private void RelaxNode(GNode node)
        {
            for(int i=0; i< node.pEdgeList.Count; i++)
            {
                var neighbor_node = node.pEdgeList[i].source_.number_ == node.pNumber ? node.pEdgeList[i].source_ : node.pEdgeList[i].sink_;
                if (neighbor_node.distance_to_source_ + node.pEdgeList[i].weight_ > node.distance_to_source_ )
            }
        }*/

        public static void Relax(GNode u, GNode v, int weight)
        {
            if (v.distance_to_source_ > u.distance_to_source_ + weight)
            {
                v.distance_to_source_ = u.distance_to_source_ + weight;
                v.parent_ = u;
            }
        }
    }
}
