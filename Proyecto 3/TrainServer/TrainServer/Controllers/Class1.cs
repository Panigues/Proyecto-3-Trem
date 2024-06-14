using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public string Name { get; set; }
    public List<Edge> Edges { get; set; }
    public int Distance { get; set; }
    public Node Previous { get; set; }

    public Node(string name)
    {
        Name = name;
        Edges = new List<Edge>();
        Distance = int.MaxValue;
    }
}

public class Edge
{
    public Node Node { get; set; }
    public int Weight { get; set; }

    public Edge(Node node, int weight)
    {
        Node = node;
        Weight = weight;
    }
}

public class Graph
{
    public List<Node> Nodes { get; set; }

    public Graph()
    {
        Nodes = new List<Node>();
    }

    public void AddNode(string name)
    {
        Nodes.Add(new Node(name));
    }

    public void AddEdge(string from, string to, int weight)
    {
        Node fromNode = Nodes.FirstOrDefault(n => n.Name == from);
        Node toNode = Nodes.FirstOrDefault(n => n.Name == to);

        if (fromNode != null && toNode != null)
        {
            fromNode.Edges.Add(new Edge(toNode, weight));
            toNode.Edges.Add(new Edge(fromNode, weight));
        }
    }

    public List<string> Dijkstra(string start, string end)
    {
        Node startNode = Nodes.FirstOrDefault(n => n.Name == start);
        Node endNode = Nodes.FirstOrDefault(n => n.Name == end);

        if (startNode == null || endNode == null)
        {
            return new List<string>();
        }

        foreach (Node node in Nodes)
        {
            node.Distance = int.MaxValue;
            node.Previous = null;
        }

        startNode.Distance = 0;

        List<Node> unvisitedNodes = new List<Node>(Nodes);

        while (unvisitedNodes.Count > 0)
        {
            Node currentNode = unvisitedNodes.OrderBy(n => n.Distance).First();

            if (currentNode == endNode)
            {
                break;
            }

            unvisitedNodes.Remove(currentNode);

            foreach (Edge edge in currentNode.Edges)
            {
                Node neighbor = edge.Node;
                int distance = currentNode.Distance + edge.Weight;

                if (distance < neighbor.Distance)
                {
                    neighbor.Distance = distance;
                    neighbor.Previous = currentNode;
                }
            }
        }

        List<string> path = new List<string>();

        Node currentNodePath = endNode;
        while (currentNodePath != null)
        {
            path.Add(currentNodePath.Name);
            currentNodePath = currentNodePath.Previous;
        }

        path.Reverse();

        return path;
    }
}