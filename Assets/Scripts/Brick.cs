using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject smoke;
    public AudioClip crack;
    public static int breakableCount = 0; 
    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        isBreakable = this.tag == "Breakable";
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

        if (isBreakable)
        {
            breakableCount++;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ++timesHit;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        print("breakable:" +breakableCount);
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
        if (timesHit >= hitSprites.Length)
        {
            PuffSmoke();
            Destroy(gameObject);
            breakableCount--;
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
