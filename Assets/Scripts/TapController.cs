using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public float tapForce = 250;
    public float tiltSmooth = 2;
    public Vector3 stopPosition;

    public static Rigidbody2D rigidBody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    public GameObject startPage;
    public GameObject gameOverPage;
    public Text scoreText;
    public static int score = 0;
    public static bool gameOver = false;
    public enum PageState
    {
        None,
        Start,
        GameOver
    }

    // Use this for initialization
    void Start()
    {
        // Debug.Log("Hello world!");

        rigidBody = GetComponent<Rigidbody2D>();

        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // left-click on PC OR tap on mobiles
        {
            transform.rotation = forwardRotation;

            rigidBody.velocity = Vector3.zero;
            rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {      
        if (col.gameObject.tag == "ScoreZone")
        {
            // get a score
            score++;
            scoreText.text = score.ToString();

            // play a sound

        }

        if (col.gameObject.tag == "DeadZone")
        {
            rigidBody.simulated = false;           // freeze the astronaut

            // game over
            gameOver = true;
            int savedScore = PlayerPrefs.GetInt("BestScore");
            if (score > savedScore)
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
            setPageState(PageState.GameOver);


            // play a sound

        }
    }

    void setPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                break;

            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                break;

            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                break;
        }
    }


}
