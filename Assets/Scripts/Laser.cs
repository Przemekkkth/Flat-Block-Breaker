using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if( collision.tag == "Unbreakable Block" || collision.tag == "Breakable Block" || collision.tag == "Additional Block")
        {
            collision.gameObject.GetComponent<Block>().BlockDestroy();
            Destroy(gameObject);
        }
    }
}
