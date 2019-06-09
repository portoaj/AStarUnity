using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject normalTile;
    [SerializeField] GameObject waterTile;
    static int width;
    static int height;
    [SerializeField] float normalChance;
    public static Node[,] nodesOrdered;
    public static List<Node> allNodes = new List<Node>();
    // Start is called before the first frame update
    void Awake()
    {
        width = 10;
        height = 10;
        nodesOrdered = new Node[width, height];
        //Generate tilemap
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Random.Range(0f, 1f) < normalChance)
                {
                    GameObject newTile = Instantiate(normalTile, new Vector3(x, y, 0f), Quaternion.identity);
                    newTile.transform.SetParent(gameObject.transform);
                    Node newNode = newTile.GetComponent<Node>();
                    allNodes.Add(newNode);
                    nodesOrdered[x, y] = newNode;
                    newNode.setX(x);
                    newNode.setY(y);
                }
                else
                {
                    GameObject newTile = Instantiate(waterTile, new Vector3(x, y, 0f), Quaternion.identity);
                    newTile.transform.SetParent(gameObject.transform);
                    Node newNode = newTile.GetComponent<Node>();
                    allNodes.Add(newNode);
                    nodesOrdered[x, y] = newNode;
                    newNode.setX(x);
                    newNode.setY(y);
                }
            }
        }
        
    }
    public static List<Node> getNeighbors(Node currentNode)
    {
        List<Node> neighbors = new List<Node>();
        int nodex = currentNode.getX();
        int nodey = currentNode.getY();
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                Debug.Log("x: " +  x + "y: " + y);
                if (nodex + x >= width || nodex + x < 0 || nodey + y >= height || nodey + y < 0)
                {
                    Debug.Log("yeet4");
                    continue;
                }
                else if (nodesOrdered[nodex + x, nodey + y] == currentNode)
                {
                    Debug.Log("yeet5");
                    continue;
                }
                else
                {
                    Debug.Log("yeet6");
                    neighbors.Add(nodesOrdered[nodex + x, nodey + y]);
                }
            }
        }
        return neighbors;
    }
    public static Node getNodeFromPos(int x, int y)
    {
        return nodesOrdered[x, y];
    }
}
