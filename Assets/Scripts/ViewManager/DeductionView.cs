using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// DeductionView is enabled when you need to enter the corresponding phonemes of the object's name
// from the available phoneme inventory to unlock a corresponding clue.
public class DeductionView : View
{
    // List of canvases associated with the deduction view.
    //- DialogueCanvas: Represents the dialogue canvas which displays the dialogue text with the answer key frame.
    //- AnswerKeyFrame: Represents the answer key frame which displays the object's name and the corresponding phonemes.
    //- InventoryCanvas: Represents the phoneme inventory canvas which displays the available phonemes.
    //These can be added in the inspector.
    [SerializeField] List<GameObject> canvases = new List<GameObject>();

    // Initialize the deduction view.
    public override void Initialize()
    {
        Debug.Log("Deduction Initialize");
    }

    // Hide the deduction view and clear the phoneme stack.
    public override void Hide()
    {
        //Refreshes the stack that tracks the clicked phoneme keys when the view is disabled as it may be used for another answer key.
        PhonemeKeyManager.instance.ClearClickedPhonemeStack();

        // Deactivate all canvases associated with the deduction view.
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }
    }

    // Show the deduction view.
    public override void Show()
    {
        // Activate all canvases associated with the deduction view.
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(true);
        }
    }
}