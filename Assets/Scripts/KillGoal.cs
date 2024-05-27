// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class KillGoal : Goal
// {
//     public int EnemyID { get; set; }

//     public KillGoal(int enemyID, string title, string description, bool completed, int currentAmt, int requiredAmt) {
//         this.EnemyID = enemyID;
//         this.title = title; 
//         this.description = description;
//         this.isComplete = completed; 
//         this.currentAmt = currentAmt;
//         this.requiredAmt = requiredAmt; 
//     }

//     public override void Init() {
//         base.Init(); 
//     }

//     void EnemyDied(Enemy enemy) {
//         if (enemy.ID == this.Init) {
//             this.currentAmt++; 
//             Evaluate(); 
//         }
//     }
// }
