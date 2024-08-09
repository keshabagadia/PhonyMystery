using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeductionView : View
{
    [SerializeField] List<GameObject> canvases = new List<GameObject>();
    [SerializeField] protected AnswerKeyManager answerKeyManager;
    public override void Initialize()
    {
        Debug.Log("Deduction Initialize");
    }

    public override void Hide()
    {
        PhonemeKeyManager.instance.ClearClickedPhonemeStack();
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

}
