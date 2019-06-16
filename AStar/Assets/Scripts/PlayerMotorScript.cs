using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotorScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Pathfinding pf;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
        pf.AStar(transform.position.x, transform.position.y, target.position.x, target.position.y);
    }
}
