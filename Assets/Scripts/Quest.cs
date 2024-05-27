using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Quest
{
    public string title { get; set; }
    public string description { get; set; }
    public bool isComplete { get; set; }
    public int currentAmt { get; set; }
    public int requiredAmt { get; set; }

    public Quest(string title, string description, bool completed, int currentAmt, int requiredAmt) {
        this.title = title; 
        this.description = description;
        this.isComplete = completed; 
        this.currentAmt = currentAmt;
        this.requiredAmt = requiredAmt; 
    }

    public void Complete() {
        isComplete = true; 
    }
}
