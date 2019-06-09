using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] bool water;
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] int gScore = int.MaxValue;
    [SerializeField] int hScore = int.MaxValue;
    [SerializeField] Node parent;
    // Start is called before the first frame update
    public bool getWater()
    {
        return water;
    }
    public int getFScore()
    {
        return gScore + hScore;
    }
    public int getGScore()
    {
        return gScore;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public Node getParent()
    {
        return parent;
    }
    public void setGScore(int _gScore)
    {
        gScore = _gScore;
    }
    public void setHScore(int _hScore)
    {
        hScore = _hScore;
    }
    public void setParent(Node _parent)
    {
        parent = _parent;
    }
    public void setX(int _x)
    {
        x = _x;
    }
    public void setY(int _y)
    {
        y = _y;
    }
}
