using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject buttonSelector;
    //private string pauseButton = "Menu";
    private string selectButton = "joystick 1 button 0";
    private float selectorMoveDistance = 80.0f;
    private float selectorStart = -20.0f;
    private bool wasUp = false;

    // Use this for initialization
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {

        if ((Input.GetAxisRaw("Vertical") >= 0.8) || (Input.GetAxisRaw("Vertical") <= -0.8)
            || (Input.GetAxisRaw("Mouse Y") * 10 >= 0.8) || (Input.GetAxisRaw("Mouse Y") * 10 <= -0.8))
        {
            if (buttonSelector.transform.localPosition.y == selectorStart && !wasUp)
            {
                buttonSelector.transform.localPosition = new Vector3(buttonSelector.transform.localPosition.x,
                    -selectorMoveDistance, buttonSelector.transform.localPosition.z);
            }
            else if (buttonSelector.transform.localPosition.y == -selectorMoveDistance && !wasUp)
            {
                buttonSelector.transform.localPosition = new Vector3(buttonSelector.transform.localPosition.x,
                    selectorStart, buttonSelector.transform.localPosition.z);
            }
            wasUp = true;
        }
        else
        {
            wasUp = false;
        }

        if (Input.GetKeyDown(selectButton))
        {
            if (buttonSelector.transform.localPosition.y == selectorStart)
            {
                StartGame();
            }
            else
            {
                ExitGame();
            }
        }
    }

    void StartGame()
    {
        //reloadLevelText = wonGameMenu.GetComponent<Transform>().GetChild(0).gameObject;
        //reloadLevelText.SetActive(true);
        //GameState.ResetGameState();
        SceneManager.LoadScene("destructible_crate_prototype");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
