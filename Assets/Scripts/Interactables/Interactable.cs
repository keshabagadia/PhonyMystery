using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    public DialogueSequence dialogueSequence;
    public Button button;
    public virtual void Awake()
    {
        button = GetComponent<Button>();
        dialogueSequence = GetComponent<DialogueSequence>();
    }
    public virtual void Interact(){
        dialogueSequence.StartSequence();
    }
    public virtual void Enable(){
        button.enabled = true;
    }
    public virtual void Disable(){
        button.enabled = false;
    }
    public virtual void StartDialogue()
    {
        dialogueSequence.StartSequence();
    }
}
