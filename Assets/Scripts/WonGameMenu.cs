using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonGameMenu : MonoBehaviour {

    public GameObject wonGameMenu;
    public GameObject reloadLevelText;
    public GameObject mainMenuText;
    public GameObject buttonSelector;
    //private string pauseButton = "Menu";
    private string selectButton = "joystick 1 button 0";
    private float selectorMoveDistance = 40.0f;
    private bool wasUp = false;

    // Use this for initialization
    void Start()
    {
        wonGameMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.GameWon())
        {
            wonGameMenu = GetComponent<Transform>().GetChild(1).gameObject;
            wonGameMenu.gameObject.SetActive(true);
            reloadLevelText.SetActive(false);
            mainMenuText.SetActive(false);

            // disable the AI so that we don't lose after we win
            Destroy(GameObject.Find("claire"));

            if ((Input.GetAxisRaw("Vertical") >= 0.8) || (Input.GetAxisRaw("Vertical") <= -0.8)
            || (Input.GetAxisRaw("Mouse Y") * 10 >= 0.8) || (Input.GetAxisRaw("Mouse Y") * 10 <= -0.8))
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

            if (Input.GetKeyDown(selectButton))
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
        reloadLevelText = wonGameMenu.GetComponent<Transform>().GetChild(0).gameObject;
        reloadLevelText.SetActive(true);
        GameState.ResetGameState();
        SceneManager.LoadScene("destructible_crate_prototype");
    }

    void MainMenu()
    {
        mainMenuText = wonGameMenu.GetComponent<Transform>().GetChild(1).gameObject;
        mainMenuText.SetActive(true);
        GameState.ResetGameState();
        SceneManager.LoadScene("Main Menu");
    }

}
