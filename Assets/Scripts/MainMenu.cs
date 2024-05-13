using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public static bool isPaused = false;
   public GameObject OptionsMenu;
   public GameObject PauseMenu;

    public void OnPause()
    {
        Pause();
    }

    public void Pause()
    {
        if (isPaused == true)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

        }
        else
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

   public void NavButton(string sceneName)
   {
        SceneManager.LoadScene(sceneName);

   }

   public void QuitGame()
   {
        Application.Quit();
        Debug.Log("Quit the application.");  
   }
}
