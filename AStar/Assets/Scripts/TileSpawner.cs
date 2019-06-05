using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject normalTile;
    [SerializeField] GameObject waterTile;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int offsetX;
    [SerializeField] int offsetY;
    [SerializeField] float normalChance;
    public static List<Node> allNodes = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        //Generate tilemap
        for(int x = offsetX; x < width + offsetX; x++)
        {
            for(int y = offsetY; y < height + offsetY; y++)
            {
                if(Random.Range(0f,1f) < normalChance)
                {
                    GameObject newTile = Instantiate(normalTile, new Vector3(x, y, 0f), Quaternion.identity);
                    newTile.transform.SetParent(gameObject.transform);
                    allNodes.Add(newTile.GetComponent<Node>());
                }
                else
                {
                    GameObject newTile = Instantiate(waterTile, new Vector3(x, y, 0f), Quaternion.identity);
                    newTile.transform.SetParent(gameObject.transform);
                    allNodes.Add(newTile.GetComponent<Node>());
                }
            }
        }
    }
}
