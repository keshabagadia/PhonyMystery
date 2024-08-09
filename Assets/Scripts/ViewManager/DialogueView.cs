using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// DialogueView class manages the dialogue system UI.
public class DialogueView : View
{
    // List of canvases associated with the dialogue view.
    //Only include the DialogueCanvas in the inspector for now, but initialised as a list for future expansion.
    [SerializeField] List<GameObject> canvases = new List<GameObject>();

    // Reference to the TMP_Text component for displaying the speaker's name.
    [SerializeField] TMP_Text dialogueName;

    // Reference to the TMP_Text component for displaying the dialogue content.
    [SerializeField] TMP_Text dialogueContent;

    // Initialize the dialogue view.
    public override void Initialize()
    {
        Debug.Log("Dialogue Initialize");
    }

    // Hide the dialogue view.
    public override void Hide()
    {
        // Deactivate all canvases associated with the dialogue view.
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }

    // Show the dialogue view.
    public override void Show()
    {
        // Activate all canvases associated with the dialogue view.
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }
    }

    // Set the speaker's name in the dialogue view.
    public void SetSpeaker(string nameString)
    {
        dialogueName.text = nameString;
    }

    //Set the dialogue content in the dialogue view.
    public void SpeakDialogue(string content)
    {
        dialogueContent.text = content;
    }
}