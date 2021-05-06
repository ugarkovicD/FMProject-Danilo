using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{

    public void ChangeToScene()
    {
        SceneManager.LoadScene("Mmenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("TestScene");
    }
}