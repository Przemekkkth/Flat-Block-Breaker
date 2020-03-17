using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    void Update()
    {
        Vector2 mousePositionInUnits = new Vector2( Mathf.Clamp( (Input.mousePosition.x / Screen.width) * screenWidthInUnits, minX, maxX), transform.position.y);
        transform.position = mousePositionInUnits;
    }
}
