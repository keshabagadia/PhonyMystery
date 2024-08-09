using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

// Abstract base class for all key objects in the game.
// Implements IPointerClickHandler to handle pointer click events.
public abstract class Key : MonoBehaviour, IPointerClickHandler
{
    // Reference to the TMP_Text component for displaying text on the key.
    public TMP_Text displayText;

    // Reference to the Image component for the background of the key.
    public Image bgImage;

    // Reference to the AudioSource component for playing audio clips.
    public AudioSource audioSource;

    // Awake is called when the script instance is being loaded.
    // Initializes the components and checks for their existence.
    public virtual void Awake()
    {
        // Get the Image component attached to the GameObject.
        bgImage = gameObject.GetComponent<Image>();
        if (bgImage == null)
        {
            Debug.LogError("Image component not found on the " + gameObject.name + ".");
        }

        // Get the AudioSource component attached to the GameObject.
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the " + gameObject.name + ".");
        }
        else
        {
            // Ensure the audio does not play on awake.
            audioSource.playOnAwake = false;
        }

        // Get the TMP_Text component from the children of the GameObject.
        displayText = gameObject.GetComponentInChildren<TMP_Text>();
        if (displayText == null)
        {
            Debug.LogError("TMP_Text component not found in the children of the " + gameObject.name + ".");
        }
    }

    // Initialize the key. Can be overridden by derived classes.
    public virtual void Initialize()
    {
        Debug.Log("Initialized " + gameObject.name);
    }

    // Handle pointer click events.
    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the left mouse button was clicked.
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        //Can be expanded for right mouse button click events if needed.
    }

    // Handle left click events. Can be overridden by derived classes.
    public virtual void OnLeftClick()
    {
        Debug.Log("Left click on " + gameObject.name);
        PlayAudio();
    }

    // Set the background color of the key.
    public void SetColor(Color c)
    {
        bgImage.color = c;
    }

    // Play the audio clip attached to the AudioSource.
    public void PlayAudio()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}