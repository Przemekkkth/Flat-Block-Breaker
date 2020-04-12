using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Ball" && ( collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0) )
        {
            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
