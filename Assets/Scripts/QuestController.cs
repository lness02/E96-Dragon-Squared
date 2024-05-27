using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class QuestController : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public int questsCompleted = 0; 
    [SerializeField] public int totalQuests = 2; 
    public GameObject questPrefab; // Prefab of the task UI element
    public Transform questListParent;
    private float verticalSpacing = 75f; 
    // Start is called before the first frame update
    void Awake()
    {
        // populate quest list with quests
        AddQuest("Punch a tree", "Punch a tree to rebuild homes.", false, 0, 1);
        AddQuest("We Didn’t Start the Fire!", "Break down the village water dam to put out the town.", false, 0, 1);
        AddQuest("Clean the Streets (>:3)", "There's this sus lord. Do what you do best and murder!", false, 0, 1);
        AddQuest("Clean the Streets", "Clean Up Debris.", false, 0, 1);
        AddQuest("No Witnesses. ", "Someone knows that you destroyed the town. Take him down.", false, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Quest q in quests) {
            if (q.currentAmt >= q.requiredAmt) {
                CompleteQuest(q); 
            }
        }

        // listen for events that indicate a quest was completed
    }

    public void AddQuest(string title, string description, bool completed, int currentAmt, int requiredAmt) {
        Quest q = new Quest(title, description, completed, currentAmt, requiredAmt);
        quests.Add(q); 
        // totalQuests++; 
        Debug.Log(q); 
        // add to UI
        UpdateUI(); 
    }

    // // have event listeners somehow?
    public void UpdateQuest(Quest q, int update) {
        q.currentAmt = update; 
    }
    
    public void CompleteQuest(Quest q) {
        q.Complete(); 
        questsCompleted++; 

        // remove from UI
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        // clear existing
        foreach (Transform child in questListParent)
        {
            Destroy(child.gameObject);
        }

        // UI elements
        float yPos = 140f;
        foreach (Quest q in quests)
        {
            GameObject questUI = Instantiate(questPrefab, questListParent);
            // Set the position of the instantiated prefab
            RectTransform rectTransform = questUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, yPos);

            // Update the current Y position for the next prefab
            // yPos -= (rectTransform.sizeDelta.y + verticalSpacing);
            yPos -= (verticalSpacing);

            // update text
            TextMeshProUGUI[] textComponents = questUI.GetComponentsInChildren<TextMeshProUGUI>();
            if (textComponents.Length > 0)
            {
                textComponents[0].text = q.title;
                Debug.Log(q.title); 
            }

            if (textComponents.Length > 1)
            {
                textComponents[1].text = q.description;
            }
        }
    }

}
