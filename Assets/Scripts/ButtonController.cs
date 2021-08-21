using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject austronat;

    public Button playButton;
    public Button rePlayButton;

    public Text scoreText;


    public void OnPlayClicked()
    {
        startPage.SetActive(false);
        gameOverPage.SetActive(false);
        TapController.score = 0;
        TapController.rigidBody.simulated = true;
        TapController.IsGameActive = true;
    }

    public void OnReplayClicked()
    {
        startPage.SetActive(false);
        gameOverPage.SetActive(false);
        TapController.score = 0;
        TapController.rigidBody.simulated = true;
        TapController.IsGameActive = true;

        // reset the score
        scoreText.text = "0";

        // reset scene
        SceneManager.LoadScene(0);

        // reposition austronaut to the basic position
        // (-2.37, 0.63)
        //transform.position = new Vector2(-2.37f, 0.63f);
        //TapController.rigidBody.transform.position = TapController.stopPosition;
        //austronat.transform.position = new Vector2(-2.37f, 0.63f);

        // remove all the obstacles created
        //ObstaclePooling.DestroyObstacles();
    }

    void Start()
    {
        Button btn1 = playButton.GetComponent<Button>();
        btn1.onClick.AddListener(OnPlayClicked);

        Button btn2 = rePlayButton.GetComponent<Button>();
        btn2.onClick.AddListener(OnReplayClicked);
    }

    void Update()
    {

    }
}
