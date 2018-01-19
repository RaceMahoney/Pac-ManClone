using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {

    public float speed = 0.3f;
    Vector2 dest = Vector2.zero;

	void Start () {
        dest = transform.position;
        StartCoroutine(Delay());

    }
	

	void FixedUpdate () {

        //Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        //Get movement 
       
            if (Input.GetKey(KeyCode.W) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;

            if (Input.GetKey(KeyCode.D) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;

            if (Input.GetKey(KeyCode.S) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;

            if (Input.GetKey(KeyCode.A) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;

        
               
       
        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);

    }
}
