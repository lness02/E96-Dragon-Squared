using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public List<Quest> questsToRemove = new List<Quest>();
    public int questsCompleted = 0; 
    public int totalQuests = 3; 
    public GameObject questPrefab;
    public Transform questListParent;
    public TextMeshProUGUI questNum; 
    private float verticalSpacing = 50f; 

    void Start()
    {
        // populate quest list with quests
        AddQuest("Punch a tree", "Punch a green tree stump to rebuild homes.", false, 0, 1);
        AddQuest("Clean the Streets (>:3)", "Murder the sus (fox) lord.", false, 0, 1);
        AddQuest("No Witnesses.", "Take down a raccoon who knows you destroyed the town.", false, 0, 1);

        // listen for Enemy deaths
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemies) { 
            e.onDeath.AddListener(OnEnemyDeath);
        }
    }

    void Update()
    {
        // check for completion
        foreach (Quest q in quests) {
            if (q.currentAmt >= q.requiredAmt) {
                CompleteQuest(q); 
            }
        }

        // remove ze quest
        foreach (Quest q in questsToRemove) {
            quests.Remove(q); 
        }

        // update ze UI
        if (questsToRemove.Count > 0) {
            // remove from UI
            UpdateUI(); 
            questsToRemove.Clear();
        }

        // if all quests are completed, game over
        if (questsCompleted == totalQuests) {
            GameOver(); 
        }

    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");  
    }

    public void AddQuest(string title, string description, bool completed, int currentAmt, int requiredAmt) {
        Quest q = new Quest(title, description, completed, currentAmt, requiredAmt);
        quests.Add(q); 
        // add to UI
        UpdateUI(); 
    }

    public void UpdateQuest(Quest q, int update) {
        q.currentAmt = update; 
    }

    // event handler for enemy death (used for task triggers)
    private void OnEnemyDeath(GameObject enemy)
    {
        Debug.Log(enemy); 
        if (enemy.CompareTag("TreeEnemy")) {
            foreach (Quest q in quests) {
                if (q.title == "Punch a tree") {
                    UpdateQuest(q, 1);
                }
            }
        }
        if (enemy.CompareTag("SusLord")) {
            foreach (Quest q in quests) {
                if (q.title == "Clean the Streets (>:3)") {
                    UpdateQuest(q, 1);
                }
            }
        }
        if (enemy.CompareTag("RaccoonWitness")) {
            foreach (Quest q in quests) {
                if (q.title == "No Witnesses.") {
                    UpdateQuest(q, 1);
                }
            }
        }
        
    }
    
    public void CompleteQuest(Quest q) {
        q.Complete(); 
        questsCompleted++; 

        // remove from quest list
        questsToRemove.Add(q); 
    }

    // update task list
    private void UpdateUI()
    {
        // clear existing
        foreach (Transform child in questListParent)
        {
            Destroy(child.gameObject);
        }

        // UI elements
        questNum.text = questsCompleted.ToString(); 
        float yPos = 140f;
        foreach (Quest q in quests)
        {
            GameObject questUI = Instantiate(questPrefab, questListParent);
            RectTransform rectTransform = questUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, yPos);

            // yPos -= (rectTransform.sizeDelta.y + verticalSpacing);
            yPos -= (verticalSpacing);

            // update text
            TextMeshProUGUI[] textComponents = questUI.GetComponentsInChildren<TextMeshProUGUI>();
            if (textComponents.Length > 0)
            {
                textComponents[0].text = q.title;
            }

            if (textComponents.Length > 1)
            {
                textComponents[1].text = q.description;
            }
        }
    }

}
