using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public static bool isPaused = false;
   public static bool isOptionsOpen = false;
   public static bool isCreditsOpen = false;
   public static bool isHelpOpen = false;

   public GameObject PauseMenu;
   public GameObject OptionsMenu;
   public GameObject CreditsMenu;

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

//     public void Help()
//     {
//         if (isHelpOpen == true && isPaused == false)
//         {
//             HelpMenu.SetActive(false);
//             Time.timeScale = 1f;
//             isHelpOpen = false;

//         }
//         else if(isPaused == false)
//         {
//             HelpMenu.SetActive(true);
//             Time.timeScale = 0f;
//             isHelpOpen = true;
//         }
//     }

   public void NavButton(string sceneName)
   {
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
