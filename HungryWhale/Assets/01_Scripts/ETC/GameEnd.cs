using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        FailCheck();
        SuccessCheck();
    }

    private void FailCheck()
    {
        if (player.HP <= 0) SceneManager.LoadScene("Fail");
    }

    private void SuccessCheck()
    {
        if (GameManager.Instance.FishCount >= 50) SceneManager.LoadScene("Success");
    }
}
