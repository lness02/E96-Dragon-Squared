using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionManager : MonoBehaviour
{
    private void Awake()
    {
        LoadPosition();
    }

    public void SavePosition()
    {
        Vector3 playerPosition = transform.position;
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetFloat(currentScene + "_PlayerX", playerPosition.x);
        PlayerPrefs.SetFloat(currentScene + "_PlayerY", playerPosition.y);
        PlayerPrefs.SetFloat(currentScene + "_PlayerZ", playerPosition.z);
        PlayerPrefs.Save();
    }

    public void LoadPosition()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey(currentScene + "_PlayerX") && PlayerPrefs.HasKey(currentScene + "_PlayerY") && PlayerPrefs.HasKey(currentScene + "_PlayerZ"))
        {
            float x = PlayerPrefs.GetFloat(currentScene + "_PlayerX");
            float y = PlayerPrefs.GetFloat(currentScene + "_PlayerY");
            float z = PlayerPrefs.GetFloat(currentScene + "_PlayerZ");
            transform.position = new Vector3(x, y, z);
        }
    }
}
