using UnityEngine;
using System.Collections.Generic;

public class LockedClue : Interactable
{
    [SerializeField] private List<UnlockedClue> toInteractClues;
    [SerializeField] private UnlockedClue unlockedClue;
    public bool isQuestion = false;
    // Add any additional properties or variables here

    public void Start()
    {
        //base.Start();
        unlockedClue.Disable();
    }

    public override void Interact()
    {
        //if all clues to interact with have not been interacted with, play default dialogue
        if(!CheckToInteractClues())
        {
            StartDialogue();
        } else//if all clues to interact with have been interacted with, unlock the clue
        {
            UnlockClue();
        }
    }

    private bool CheckToInteractClues()
    {
        foreach (var c in toInteractClues)
        {
            if (!c.playerHasInteracted)
            {
                return false;
            }
        }
        return true;
    }

    private void UnlockClue()
    {
        Disable();
        unlockedClue.Enable();
        unlockedClue.Interact(isQuestion);
    }
}