using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    public Transform[] waypoints;
    public float speed = 0.3f;

    private int cur = 0;




    void FixedUpdate () {

        if (Vector2.Distance(transform.position, waypoints[cur].position) > 0.01f)
        {
            //find the needed vector to get to the next position 
            Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            //Move the Rigidbody object to that found positon
            GetComponent<Rigidbody2D>().MovePosition(pos);
           
        }
        else
        {
            //waypoint has been reached
            //move to next one
            Debug.Log(cur);
            cur = (cur + 1) % waypoints.Length;
        }

        //Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if pacman runs into ghosts
        //kill him
        if(collision.name == "pacman")
        {
            Destroy(collision.gameObject);
        }
    }

 
}
