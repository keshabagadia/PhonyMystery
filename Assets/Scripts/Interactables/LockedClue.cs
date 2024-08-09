using UnityEngine;
using System.Collections.Generic;

// LockedClue class represents a clue that is initially locked and can be unlocked by interacting with other clues.
public class LockedClue : Interactable
{
    // List of clues that need to be interacted with to unlock this clue.
    [SerializeField] private List<UnlockedClue> toInteractClues;

    // The clue that will be unlocked.
    [SerializeField] private UnlockedClue unlockedClue;

    // Flag to indicate if this clue is a question.
    public bool isQuestion = false;

    // Start is called before the first frame update.
    public void Start()
    {
        // Disable the unlocked clue at the start.
        unlockedClue.Disable();
    }

    // Interact with the locked clue.
    public override void Interact()
    {
        // If not all required clues have been interacted with, start the default dialogue.
        if (!CheckToInteractClues())
        {
            StartDialogue();
        }
        else // If all required clues have been interacted with, unlock the clue.
        {
            UnlockClue();
        }
    }

    // Check if all required clues have been interacted with.
    private bool CheckToInteractClues()
    {
        // Iterate through each clue in the list.
        foreach (var c in toInteractClues)
        {
            // If any clue has not been interacted with, return false.
            if (!c.playerHasInteracted)
            {
                return false;
            }
        }
        // If all clues have been interacted with, return true.
        return true;
    }

    // Unlock the clue.
    private void UnlockClue()
    {
        // Disable the current locked clue.
        Disable();

        // Enable the unlocked clue.
        unlockedClue.Enable();

        // Interact with the unlocked clue, passing the isQuestion flag.
        unlockedClue.Interact(isQuestion);
    }
}