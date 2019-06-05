using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] bool walkable;
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] int gScore;
    [SerializeField] int hScore;
    // Start is called before the first frame update
    public bool getWalkable()
    {
        return walkable;
    }
    public int getFScore()
    {
        return gScore + hScore;
    }
}
