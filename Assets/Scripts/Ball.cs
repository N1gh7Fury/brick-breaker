using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector;
    public bool hasStarted;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        hasStarted = false;
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}

    public void AutoPlay()
    {
        hasStarted = true;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 12f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            this.GetComponent<AudioSource>().Play();
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity += tweak;
    }

    // Update is called once per frame
    void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 12f);
            }
        }

	}

}
