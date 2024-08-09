using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public abstract class Key : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text displayText;
    public Image bgImage;
    public AudioSource audioSource;    

    public virtual void Awake()
    {
        bgImage = gameObject.GetComponent<Image>();
        if (bgImage == null)
        {
            Debug.LogError("Image component not found on the " + gameObject.name + ".");
        }
    
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the "+ gameObject.name +".");
        } else {
            audioSource.playOnAwake = false;
        }
    
        displayText = gameObject.GetComponentInChildren<TMP_Text>();
        if (displayText == null)
        {
            Debug.LogError("TMP_Text component not found in the children of the " + gameObject.name + ".");
        }
    }
    public virtual void Initialize(){
        Debug.Log("Initialized " + gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }    
    }


    public virtual void OnLeftClick()
    {
        Debug.Log("Left click on " + gameObject.name);
        PlayAudio();
    }

    public void SetColor(Color c)
    {
        bgImage.color = c;
    }

    public void PlayAudio()
    {
        if(audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

}
