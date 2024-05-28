using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public static bool isPaused = false;
   public static bool isOptionsOpen = false;
<<<<<<< Updated upstream
   public static bool isCreditsOpen = false;
   public static bool isHelpOpen = false;

   public GameObject PauseMenu;
   public GameObject OptionsMenu;
   public GameObject CreditsMenu;
=======
   public static bool isTaskOpen = false;

   public GameObject PauseMenu;
   public GameObject OptionsMenu;
   public GameObject TaskMenu;
>>>>>>> Stashed changes

   AudioManager audioManager;

   private void Awake()
   {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

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

    public void OnOptions()
    {
        PlayPageFlip();
        Options();
        
    }

    public void Options()
    {
        if (isOptionsOpen == true)
        {
            OptionsMenu.SetActive(false);
            isOptionsOpen = false;

        }
        else
        {
            OptionsMenu.SetActive(true);
            isOptionsOpen = true;
        }
    }

<<<<<<< Updated upstream
    public void OnCredits()
    {
        PlayPageFlip();
        Credits();
        
    }

    public void Credits()
    {
        if (isCreditsOpen == true)
        {
            CreditsMenu.SetActive(false);
            isCreditsOpen = false;

        }
        else
        {
            CreditsMenu.SetActive(true);
            isCreditsOpen = true;
        }
    }
    
// public void OnHelp()
//     {
//         Help();
//     }
=======
public void OnTask()
    {
        Task();
    }
>>>>>>> Stashed changes

    public void Task()
    {
        if (isTaskOpen == true && isPaused == false)
        {
            TaskMenu.SetActive(false);
            Time.timeScale = 1f;
            isTaskOpen = false;

        }
        else if(isPaused == false)
        {
            TaskMenu.SetActive(true);
            Time.timeScale = 0f;
            isTaskOpen = true;
        }
    }

   public void NavButton(string sceneName)
   {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);

   }

   public void QuitGame()
   {
        Application.Quit();
        Debug.Log("Quit the application.");  
   }

   public void PlayPageFlip()
   {
    audioManager.PlaySFX(audioManager.openMenu);
   }
}
