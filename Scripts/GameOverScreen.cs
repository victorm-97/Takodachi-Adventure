using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Player player;
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " SCORE";
    }

    public void RespawnButton()
    {
        var check = player.GetComponent<Player>();
        //SceneManager.LoadScene("Level1");
        check.Respawn();
        gameObject.SetActive(false);

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Intro");
    }
}