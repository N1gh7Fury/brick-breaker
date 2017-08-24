using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveWithKeyboardRight();
            } else if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveWithKeyboardLeft();
            } else
            {
                moveWithMouse();
            }
        } else
        {
            if (!ball.hasStarted)
            {
                ball.AutoPlay();
            }
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPosition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPosition.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void moveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void moveWithKeyboardRight()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(paddlePos.x , 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void moveWithKeyboardLeft()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x - 0.1f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(paddlePos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
}
