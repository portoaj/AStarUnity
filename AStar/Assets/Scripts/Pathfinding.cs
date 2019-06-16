using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    List<Node> nodes = new List<Node>();
    List<Node> open = new List<Node>();
    List<Node> closed = new List<Node>();
    [SerializeField] Transform target;

    void OnDrawGizmosSelected()
    {

        rebuildPath(TileSpawner.getNearestNode(transform.position.x, transform.position.y), TileSpawner.getNearestNode(target.position.x, target.position.y));
    }
    public void rebuildPath(Node startNode, Node targetNode)
    {
       
        Node currentNode = targetNode;
        while (currentNode.getParent() != null && currentNode != startNode)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(currentNode.transform.position, currentNode.getParent().transform.position);
            currentNode = currentNode.getParent();
        }
        Debug.Log("yee");
    }
    public void AStar(Node startNode, Node targetNode)
    {
        TileSpawner.clearNodeParents();
        int county = 0;
        //Clear lists from previous AStar calls
        open.Clear();
        closed.Clear();
        //Add starting node to open list and update its fScore (by updating the g and h scores)
        open.Add(startNode);
        startNode.setGScore(0);
        updateH(startNode, targetNode);
        Node currentNode = open[0];
        while (open.Count != 0 && county < 500)
        {

            county++;

            //Default current node is the first node in the open list
            currentNode = open[0];
            updateH(currentNode, targetNode);
            int lowestFScore = open[0].getFScore();
            //Find the best current node (lowest fScore Node in open)
            foreach (Node node in open)
            {
                updateH(node, targetNode);
                int fScore = node.getFScore();
                if (fScore < lowestFScore)
                {
                    lowestFScore = fScore;
                    currentNode = node;
                }
            }

            //If current node is the target node we have found the solution: exit the loop
            if (currentNode == targetNode)
                break;
            open.Remove(currentNode);
            closed.Add(currentNode);
            List<Node> neighbors = TileSpawner.getNeighbors(currentNode);
            foreach(Node neighbor in neighbors)
            {
                if (closed.Contains(neighbor))
                    continue;
                int cost = currentNode.getGScore();
                if (neighbor.getWater())
                    cost += 2;
                else
                    cost += 1;

                if (!open.Contains(neighbor))
                    open.Add(neighbor);
                else if (cost >= neighbor.getGScore())
                    continue;
                neighbor.setParent(currentNode);
                neighbor.setGScore(cost);
                updateH(neighbor, targetNode);
            }
        }
    }
    public void AStar(float x1, float y1, float x2, float y2)
    {

        Node startNode = TileSpawner.getNearestNode(x1,y1);
        Node targetNode = TileSpawner.getNearestNode(x2, y2);
        int county = 0;
        //Clear lists from previous AStar calls
        open.Clear();
        closed.Clear();
        //Add starting node to open list and update its fScore (by updating the g and h scores)
        open.Add(startNode);
        startNode.setGScore(0);
        updateH(startNode, targetNode);
        Node currentNode = open[0];
        while (open.Count != 0 && county < 500)
        {

            county++;

            //Default current node is the first node in the open list
            currentNode = open[0];
            updateH(currentNode, targetNode);
            int lowestFScore = open[0].getFScore();
            //Find the best current node (lowest fScore Node in open)
            foreach (Node node in open)
            {
                updateH(node, targetNode);
                int fScore = node.getFScore();
                if (fScore < lowestFScore)
                {
                    lowestFScore = fScore;
                    currentNode = node;
                }
            }

            //If current node is the target node we have found the solution: exit the loop
            if (currentNode == targetNode)
                break;
            open.Remove(currentNode);
            closed.Add(currentNode);
            List<Node> neighbors = TileSpawner.getNeighbors(currentNode);
            foreach (Node neighbor in neighbors)
            {
                if (closed.Contains(neighbor))
                    continue;
                int cost = currentNode.getGScore();
                if (neighbor.getWater())
                    cost += 3;
                else
                    cost += 1;

                if (!open.Contains(neighbor))
                    open.Add(neighbor);
                else if (cost >= neighbor.getGScore())
                    continue;
                neighbor.setParent(currentNode);
                neighbor.setGScore(cost);
                updateH(neighbor, targetNode);
            }
        }
    }
    void updateH(Node node, Node targetNode)
    {
        node.setHScore(Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow(node.getX() - targetNode.getX(), 2) + Mathf.Pow(node.getY() - targetNode.getY(), 2))));
    }
}
//Sources: Wikipedia, http://mat.uab.cat/~alseda/MasterOpt/AStar-Algorithm.pdf, https://medium.com/@nicholas.w.swift/easy-a-star-pathfinding-7e6689c7f7b2