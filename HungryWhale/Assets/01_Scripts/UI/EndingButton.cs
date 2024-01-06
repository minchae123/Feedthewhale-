using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}
