using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

	public void LoadScene(int level)
	{
		SceneManager.LoadScene("Level1");
	}

	public void ExitGame()
    {

		//UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();

	}


}
