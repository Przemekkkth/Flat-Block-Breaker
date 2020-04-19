using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Config params")]
    [SerializeField] AudioClip blockDestroyClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] bool respawnPowers = false;
    [SerializeField] bool respawnLaserPlatform = false;
    [SerializeField] Powers power = null;
    [SerializeField] LaserPlatform laserPlatform = null;
    //Cached reference
    Level level;
    [Header("State variables")]
    [SerializeField] int timesHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable Block" || tag == "Additional Block")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if( timesHit >= maxHits )
            {
                BlockDestroy();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    public void BlockDestroy()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(blockDestroyClip, Camera.main.transform.position);
        if( tag == "Breakable Block")
        {
            level.BlockDestroyed();
        }
        TriggerSparklesVFX();
        TriggerPowers();
        TriggerLaserPlatform();
    }

    private void TriggerLaserPlatform()
    {
        if (respawnLaserPlatform)
        {
            if(FindObjectOfType<LaserPlatform>())
            {
                return;
            }
            if (laserPlatform)
            {
                Instantiate(laserPlatform, transform.position, Quaternion.identity);
            }
        }
    }

    private void TriggerPowers()
    {
        if(respawnPowers)
        {
            if(power)
            {
                Instantiate(power, transform.position, Quaternion.identity);
            }
        }
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable Block")
        {
            level.CountBreakableBlock();
        }
    }

    private void TriggerSparklesVFX()
    {
        GameObject vfxObject = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(vfxObject, 2f);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if( hitSprites[spriteIndex] != null )
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }
}
