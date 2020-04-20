using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlatform : MonoBehaviour
{
    [Header("Config params")]
    [SerializeField] bool isActivated = false;
    [SerializeField] Laser laser;

    //state
    Vector2 paddleToBallVector;
    Paddle paddle = null;
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        if (!paddle)
        {
            Debug.LogWarning("No found paddle");
        }
        transform.position = paddle.transform.position;
        Vector3 newPosition = new Vector3(paddle.transform.position.x,
            paddle.transform.position.y + paddle.GetComponent<PolygonCollider2D>().bounds.size.y,
            paddle.transform.position.x);
        transform.position = newPosition;
        paddleToBallVector = transform.position - paddle.transform.position;
        isActivated = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(laser, transform.position, transform.rotation);
            isActivated = false;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
