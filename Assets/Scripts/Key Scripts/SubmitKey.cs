using UnityEngine;
using UnityEngine.UI;

public class SubmitKey : Key
{
    public override void Awake()
    {
        bgImage = gameObject.GetComponent<Image>();
        if (bgImage == null)
        {
            Debug.LogError("Image component not found on the " + gameObject.name + ".");
        }
    }
    public override void OnLeftClick()
    {
        PhonemeKeyManager.instance.SubmitAnswer();
    }
}