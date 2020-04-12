using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Sprite[] sprites;
    private string type;
    private int indexOfSprites;

    public const string LARGER_BALL = "LargerBall";
    public const string SMALLER_BALL = "SmallerBall";
    public const string LARGER_PADDLE = "LargerPaddle";
    public const string SMALLER_PADDLE = "SmallerPaddle";

    string GetType(int index)
    {
        switch(index)
        {
            case 0:
                return LARGER_BALL;
            case 1:
                return SMALLER_BALL;
            case 2:
                return LARGER_PADDLE;
            case 3:
                return SMALLER_PADDLE;
            default:
                return "INVALID";
        }
    }

    int GetIndex(string type)
    {
        if( type == LARGER_BALL)
        {
            return 0;
        }
        else if( type == SMALLER_BALL)
        {
            return 1;
        }
        else if( type == LARGER_PADDLE)
        {
            return 2;
        }
        else if( type == SMALLER_PADDLE)
        {
            return 3;
        }
        else
        {
            return -1;
        }
    }

    public string Type()
    {
        return type;
    }

    public int Index()
    {
        return indexOfSprites;
    }

    void Start()
    {
        indexOfSprites = UnityEngine.Random.Range(0, sprites.Length);
        type = GetType(indexOfSprites);
        GetComponent<SpriteRenderer>().sprite = sprites[indexOfSprites];
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Paddle")
        {
            FindObjectOfType<Paddle>().SetPowers(this);
        }
    }

}
