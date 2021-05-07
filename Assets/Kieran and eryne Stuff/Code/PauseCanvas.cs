using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCanvas : MonoBehaviour
{
    public Canvas PauseMenu;
    public Canvas HowToPlay;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.enabled = false;
        HowToPlay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.enabled = true;
            Time.timeScale = 0;
        }
    }
    public void HowToPlayUI()
    {
        HowToPlay.enabled = true;
        PauseMenu.enabled = false;
    }
    public void HowToPlayClose()
    {
        HowToPlay.enabled = false;
        PauseMenu.enabled = true;
    }
    public void Resume()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
    }
}
