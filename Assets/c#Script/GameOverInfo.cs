using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverInfo : MonoBehaviour
{

    public GameObject DisabledHUD;
    public GameObject DisableGetMessage;
    public GameObject DisableStickControl;

    private void Start()
    {
    }
    private void Update()
    {
    }
    private void OnEnable()
    {

    }
    public void OnGame()
    {

        DisabledHUD.SetActive(true);
        DisableGetMessage.SetActive(true);
        DisableStickControl.SetActive(true);

        Time.timeScale = 1;
    }
    public void OffGame()
    {


        DisabledHUD.SetActive(false);
        DisableGetMessage.SetActive(false);
        DisableStickControl.SetActive(false);

        Time.timeScale = 0;
    }
}
