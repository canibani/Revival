using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheWall : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private float endPos;
    private bool moveDown = false;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < (-transform.localScale.y / 2))
        {
            moveDown = false;
        }
        else
        {
            moveDown = true;
        }

        if (moveDown /*&& Check if player has enough pickups*/)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
        }
    }
}
