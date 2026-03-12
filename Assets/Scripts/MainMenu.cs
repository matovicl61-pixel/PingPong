using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlaySinglePlayerGame()
    {
        GameMode.enableComputerPaddle = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void PlayMultiplayerGame()
    {
        GameMode.enableComputerPaddle = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		UnityEngine.Debug.Log("Quit");
		Application.Quit();
	}
}
