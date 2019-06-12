using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    List<Node> nodes = new List<Node>();
    List<Node> open = new List<Node>();
    List<Node> closed = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        //TileSpawner.getNeighbors(TileSpawner.getNodeFromPos(2,2));
        AStar(TileSpawner.getNodeFromPos(0,0), TileSpawner.getNodeFromPos(9,9));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmosSelected()
    {
        //
        foreach(Node node in nodes)
        {
            
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(node.gameObject.transform.position, new Vector3(.1f, .1f, .1f));
        }
        rebuildPath(TileSpawner.getNodeFromPos(9, 9));
    }
    void rebuildPath(Node targetNode)
    {
        Node currentNode = targetNode;
        while (currentNode.getParent() != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(currentNode.transform.position, currentNode.getParent().transform.position);
            currentNode = currentNode.getParent();
        }
    }
    void AStar(Node startNode, Node targetNode)
    {
        int county = 0;
        //Clear lists from previous AStar calls
        open.Clear();
        closed.Clear();
        //Add starting node to open list and update its fScore (by updating the g and h scores)
        open.Add(startNode);
        startNode.setGScore(0);
        updateH(startNode, targetNode);
        Node currentNode = open[0];
        while(open.Count != 0 && county < 5000)
        {

            county++;
            Debug.Log("yeet1");
            //Default current node is the first node in the open list
            currentNode = open[0];
            updateH(currentNode, targetNode);
            int lowestFScore = open[0].getFScore();
            //Find the best current node (lowest fScore Node in open)
            foreach(Node node in open)
            {
                updateH(node, targetNode);
                int fScore = node.getFScore();
                if(fScore < lowestFScore)
                {
                    lowestFScore = fScore;
                    currentNode = node;
                }
            }
            Debug.LogWarning(open.Count + " "+ currentNode.name + currentNode.getX() + " " + currentNode.getY());
            Debug.Log("yeet2" + currentNode);
            //If current node is the target node we have found the solution: exit the loop
            if (currentNode == targetNode)
                break;
            
            //Generates the neighbor nodes to be processed later
            List<Node> neighbors = TileSpawner.getNeighbors(currentNode);
            Debug.Log("yeet3" + neighbors.Count);
            foreach (Node neighbor in neighbors)
            {
                nodes.Add(neighbor);
                //Calculate the cost to get from the origin to this neighbor node moving through currentNode
                int cost;
                if (neighbor.getWater())
                {
                    Debug.Log("yeet10");
                    cost = currentNode.getGScore() + 10;
                }
                else
                    cost = currentNode.getGScore() + 1;
                //Ignore unwalkable tiles
                if(open.Contains(neighbor))
                {
                    if(neighbor.getGScore() <= cost || neighbor == targetNode)
                    {
                        continue;
                    }
                }
                else if(closed.Contains(neighbor))
                {
                    if(neighbor.getGScore() <= cost || neighbor == targetNode)
                    {
                        closed.Remove(neighbor);
                        open.Add(neighbor);
                        continue;
                    }
                }
                else
                {
                    open.Add(neighbor);
                    updateH(neighbor, targetNode);
                }
                neighbor.setGScore(cost);
                neighbor.setParent(currentNode);
            }
            closed.Add(currentNode);
        }
        if(county == 5000)
            Debug.Log("Reached maximum scan attempts");
        if (currentNode != targetNode)
            Debug.Log("A-Star could not generate a path or encountered a pathing error");
    }
    void updateH(Node node, Node targetNode)
    {
        node.setHScore((int)Mathf.Pow(node.getX() - targetNode.getX(), 2) + (int)Mathf.Pow(node.getY() - targetNode.getY(), 2));
    }
}
//Sources: Wikipedia, http://mat.uab.cat/~alseda/MasterOpt/AStar-Algorithm.pdf, https://medium.com/@nicholas.w.swift/easy-a-star-pathfinding-7e6689c7f7b2