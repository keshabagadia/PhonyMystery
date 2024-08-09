using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueView : View
{
    [SerializeField] List<GameObject> canvases = new List<GameObject>();
    // [SerializeField] GameObject inventoryCanvas;
    // [SerializeField] GameObject answerKeyFrame;
    [SerializeField] TMP_Text dialogueName;
    [SerializeField] TMP_Text dialogueContent;
    public override void Initialize()
    {
        Debug.Log("Dialogue Initialize");
    }

    public override void Hide()
    {
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }

    public override void Show()
    {
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }
    }

    public void SetSpeaker(string nameString)
    {
        dialogueName.text = nameString;
    }

    public void SpeakDialogue(string content)
    {
        dialogueContent.text = content;
    }

    // public void EnableDeduction()
    // {
    //     inventoryCanvas.SetActive(true);
    //     answerKeyFrame.SetActive(true);
    // }

    // public void DisableDeduction()
    // {
    //     inventoryCanvas.SetActive(false);
    //     answerKeyFrame.SetActive(false);
    // }

    // public void EnableInventory()
    // {
    //     inventoryCanvas.SetActive(true);
    // }
    // public void DisableInventory()
    // {
    //     inventoryCanvas.SetActive(false);
    // }


}
