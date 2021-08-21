using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameObject startPage;
    public GameObject gameOverPage;

    public void OnPlayClicked()
    {
        startPage.SetActive(false);
        gameOverPage.SetActive(false);
        TapController.score = 0;
        TapController.rigidBody.simulated = true;
    }

    public void OnReplayClicked()
    {
        startPage.SetActive(false);
        gameOverPage.SetActive(false);
        TapController.score = 0;
        TapController.rigidBody.simulated = true;
    }

    void Update()
    {

    }
}
