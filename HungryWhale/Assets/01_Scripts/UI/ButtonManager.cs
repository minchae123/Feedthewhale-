using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject _canvas;

    public void GameStart(int a)
    {
        SceneManager.LoadScene(a);
    }

    public void Explain()
    {
        _canvas.SetActive(true);
    }

    public void Close()
    {
        _canvas.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
