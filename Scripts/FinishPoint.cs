using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Text pointsText;

    public void SetupEnd(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " SCORE";
        
    }
    public void RespawnButton()
    {
       SceneManager.LoadScene("Level1");
        
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Intro");
    }
}
