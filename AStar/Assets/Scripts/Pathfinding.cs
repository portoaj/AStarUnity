using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    List<Node> nodes = new List<Node>();
    List<Node> open = new List<Node>();
    List<Node> closed = new List<Node>();
    List<Node> path = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        nodes = TileSpawner.allNodes;
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
            if(node.getWalkable())
            {
                Gizmos.color = new Color(1, 0, 0, 0.5f);
                Gizmos.DrawCube(node.gameObject.transform.position, new Vector3(.1f, .1f, .1f));
            }
        }
    }
    List<Node> AStar(Node startNode, Node targetNode)
    {
        //Clear lists from previous AStar calls
        open.Clear();
        closed.Clear();
        path.Clear();
        //Add starting node to open list
        open.Add(startNode);
        while(open.Count != 0)
        {
            Node lowestF;
        }



        return path;
    }
}
