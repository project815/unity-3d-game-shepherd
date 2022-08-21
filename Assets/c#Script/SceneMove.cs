using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public int sceneNumber;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit();
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
