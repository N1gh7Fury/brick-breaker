using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        print("Trigger");
        levelManager.LoadLevel("Lose");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

}
