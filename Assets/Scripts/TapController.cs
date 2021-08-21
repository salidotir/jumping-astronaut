using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public float tapForce = 200;
    public float tiltSmooth = 2;
    public static Vector3 stopPosition;

    public static Rigidbody2D rigidBody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    public GameObject startPage;
    public GameObject gameOverPage;
    public Text scoreText;
    public Text gameOverScoreText;
    public static int score = 0;
    public static bool IsGameActive = false;

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
        // Debug.Log(IsGameActive);

        rigidBody = GetComponent<Rigidbody2D>();

        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);

        setPageState(PageState.Start);
        IsGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameActive == true)
        {
            if (Input.GetMouseButtonDown(0))    // left-click on PC OR tap on mobiles
            {
                transform.rotation = forwardRotation;

                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
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
            IsGameActive = false;

            // save best score for later
            // int savedScore = PlayerPrefs.GetInt("BestScore");
            // if (score > savedScore)
            // {
            // PlayerPrefs.SetInt("BestScore", score);
            //  }

            // write score
            gameOverScoreText.text = score.ToString();

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
