using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Start()
    {
        //StartCoroutine(GoDown());
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
