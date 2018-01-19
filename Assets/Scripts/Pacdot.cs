using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour {
    //TODO add score increase

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
            Destroy(gameObject);
    }
}
