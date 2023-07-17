using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour
{
    public Player player;
    public Text pointsText;
    public PickUp score;

    public void Setup()
    {

        gameObject.SetActive(true);
        pointsText.text = score.count.ToString();

        if (player.finish || !player.active)
        {
            gameObject.SetActive(false);
        }
    }
}
