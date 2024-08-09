using UnityEngine;
using UnityEngine.UI;

public class BackspaceKey : SubmitKey
{
    public override void OnLeftClick()
    {
        PhonemeKeyManager.instance.BackspaceAnswerKey();
    }
}