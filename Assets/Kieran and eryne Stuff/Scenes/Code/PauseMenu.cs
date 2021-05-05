using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject pauseMenuUI;
    public GameObject HowToPlayUI;

    void Start()
    {
        GameIsPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameIsPaused = false);
        {
            pauseMenuUI.SetActive(false);
        }
        if(GameIsPaused = true);
        {
            pauseMenuUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape));
        {
            GameIsPaused = true;
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Game...");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }

    public void HowToPlayOn()
    {
        HowToPlayUI.SetActive(true);
    }
    public void HowToPlayOff()
    {
        HowToPlayUI.SetActive(false);
    }
}