using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private string WhatScene;
    private PlayerPositionManager playerPositionManager;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPositionManager = player.GetComponent<PlayerPositionManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Save player position before switching scenes
            playerPositionManager.SavePosition();
            SceneManager.LoadScene(WhatScene);
        }
    }
}
