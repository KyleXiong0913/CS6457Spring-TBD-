using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject reloadLevelText;
    public GameObject mainMenuText;
    public GameObject buttonSelector;
    private float selectorMoveDistance = 40.0f;
    private bool wasUp = false;
    
    // Use this for initialization
	void Start () {
        pauseMenu.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(GameState.buttonPause) || Input.GetKeyDown(GameState.pauseKey))
        {
            if (GameState.GamePaused())
            {
                pauseMenu.gameObject.SetActive(false);
                GameState.UnpauseGame();
            } else
            {
                GameState.PauseGame();
                pauseMenu = GetComponent<Transform>().GetChild(0).gameObject;
                pauseMenu.gameObject.SetActive(true);
                reloadLevelText.SetActive(false);
                mainMenuText.SetActive(false);
            }
        }
        if (GameState.GamePaused())
        {
            if ((Input.GetAxisRaw(GameState.verticalAxis) >= 0.8) || (Input.GetAxisRaw(GameState.verticalAxis) <= -0.8)
            || (Input.GetAxisRaw(GameState.verticalKey) >= 0.8) || (Input.GetAxisRaw(GameState.verticalKey) <= -0.8)
            || (Input.GetAxisRaw(GameState.cameraVAxis) * 10 >= 0.8) || (Input.GetAxisRaw(GameState.cameraVAxis) * 10 <= -0.8)
            || (Input.GetAxisRaw(GameState.cameraVKey) * 10 >= 0.8) || (Input.GetAxisRaw(GameState.cameraVKey) * 10 <= -0.8))
            {
                if (buttonSelector.transform.localPosition.y == 0 && !wasUp)
                {
                    buttonSelector.transform.localPosition = new Vector3(buttonSelector.transform.localPosition.x,
                        -selectorMoveDistance, buttonSelector.transform.localPosition.z);
                }
                else if (buttonSelector.transform.localPosition.y == -selectorMoveDistance && !wasUp)
                {
                    buttonSelector.transform.localPosition = new Vector3(buttonSelector.transform.localPosition.x,
                        0.0f, buttonSelector.transform.localPosition.z);
                }
                wasUp = true;
            }
            else
            {
                wasUp = false;
            }

            if ((Input.GetKeyDown(GameState.buttonA) || Input.GetKeyDown(GameState.returnKey)))
            {
                // Check height of selector
                if (buttonSelector.transform.localPosition.y == 0)
                {
                    RetryGame();
                }
                else
                {
                    MainMenu();
                }

            }
        }

        

	}

    void RetryGame()
    {
        reloadLevelText = pauseMenu.GetComponent<Transform>().GetChild(0).gameObject;
        reloadLevelText.SetActive(true);
        GameState.ResetGameState();
        SceneManager.LoadScene("destructible_crate_prototype");
    }

    void MainMenu()
    {
        mainMenuText = pauseMenu.GetComponent<Transform>().GetChild(1).gameObject;
        mainMenuText.SetActive(true);
        GameState.ResetGameState();
        SceneManager.LoadScene("Main Menu");
    }

}
