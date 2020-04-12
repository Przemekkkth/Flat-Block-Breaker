using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Config params")]
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float scaleUp = 1.3f;
    [SerializeField] float scaleDown = 0.7f;
    [SerializeField] float powerUpTime = 5f;
    [SerializeField] float powerDownTime = 5f;

    void Update()
    {
        Vector2 mousePositionInUnits = new Vector2( Mathf.Clamp( (Input.mousePosition.x / Screen.width) * screenWidthInUnits, minX, maxX), transform.position.y);
        transform.position = mousePositionInUnits;
    }

    public void SetPowers(Powers powers)
    {
        StopAllCoroutines();
        SetNormalState();
        switch( powers.Index() )
        {
            case 0:
                StartCoroutine(SetLargerBall());
                break;
            case 1:
                StartCoroutine(SetSmallerAndSemiTransparentBall());
                break;
            case 2:
                StartCoroutine(SetLargerPaddle());
                break;
            case 3:
                StartCoroutine(SetSmallerPaddle());
                break;
            default:
                Debug.LogError("Invalid powers");
                break;
        }
        StartCoroutine( SetLargerBall() );
    }


    IEnumerator SetLargerBall()
    {
        Ball theBall = FindObjectOfType<Ball>();
        if (!theBall)
        {
            yield break;
        }
        Vector3 norlmalScale = theBall.transform.localScale;
        theBall.transform.localScale = new Vector2(scaleUp, scaleUp);
        yield return new WaitForSeconds(powerUpTime);
        theBall.transform.localScale = norlmalScale;
    }

    IEnumerator SetSmallerAndSemiTransparentBall()
    {
        Ball theBall = FindObjectOfType<Ball>();
        if (!theBall)
        {
            yield break;
        }
        Vector3 norlmalScale = theBall.transform.localScale;
        Color normalColor = theBall.GetComponent<SpriteRenderer>().color;
        theBall.transform.localScale = new Vector2(scaleUp, scaleUp);
        theBall.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(powerDownTime);
        theBall.transform.localScale = norlmalScale;
        theBall.GetComponent<SpriteRenderer>().color = normalColor;

    }

    IEnumerator SetLargerPaddle()
    {
        Vector3 norlmalScale = transform.localScale;
        transform.localScale = new Vector2(scaleUp, 1f);
        yield return new WaitForSeconds(powerUpTime);
        transform.localScale = norlmalScale;
    }

    IEnumerator SetSmallerPaddle()
    {
        Vector3 norlmalScale = transform.localScale;
        transform.localScale = new Vector2(scaleDown, 1f);
        yield return new WaitForSeconds(powerDownTime);
        transform.localScale = norlmalScale;
    }

    void SetNormalState()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        Ball theBall = FindObjectOfType<Ball>();
        if(theBall)
        {
            theBall.transform.localScale = new Vector3(1f, 1f, 1f);
            theBall.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
