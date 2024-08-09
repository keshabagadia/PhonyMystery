// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class InteractableManager : MonoBehaviour
// {
//     [SerializeField] Stack<Clue> clues = new Stack<Clue>();
//     [SerializeField] Clue currentClue;
//     [SerializeField] bool playerIsInvestigating = false;

//     void Start()
//     {
//         currentClue = clues.Pop();
//         currentClue.EnableClue();
//     }

//     void Update()
//     {
//         if(clues.Count > 0)
//         {
//             if (currentClue.playerHasInteracted)
//             {
//                 currentClue.StartDialogue();
//                 currentClue.DisableClue();
//                 currentClue = clues.Pop();
//                 currentClue.EnableClue();
//             }    
//         }
//         //current  interaction mechanic
//         if(playerIsInvestigating)
//         {
//             if(Input.GetKeyDown(KeyCode.E))
//             {
//                 currentClue.playerHasInteracted = true;
//             }
//         }
//     }
        

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.tag == "Player")
//         {
//             playerIsInvestigating = true;
//         }
//     }


// }
