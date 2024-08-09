using UnityEngine;
using TMPro;

// PhonemeKey class represents a key that holds a phoneme and manages its interactions.
public class PhonemeKey : Key
{
    // The phoneme associated with this key.
    public Phoneme phoneme;

    // UI elements for displaying the phoneme count.
    [SerializeField] private GameObject countImage;
    [SerializeField] private TMP_Text countText;

    // Initialize the PhonemeKey with a specific phoneme.
    public void Initialize(Phoneme p)
    {
        phoneme = p;
        Initialize();
    }

    // Override the base Initialize method to set up the PhonemeKey.
    public override void Initialize()
    {
        // Set the name of the GameObject to the phoneme string.
        this.name = phoneme.phonemeString;

        // Set the display text to the phoneme string.
        displayText.text = phoneme.phonemeString;

        // Set the audio clip to the phoneme's audio clip.
        audioSource.clip = phoneme.audioClip;

        // Update the visual representation of the phoneme count.
        UpdateCountVisual();
    }

    // Update the visual representation of the phoneme count.
    private void UpdateCountVisual()
    {
        int count = phoneme.phonemeCount;

        // If the count is less than 1, set the color to gray and hide the count image.
        if (count < 1)
        {
            SetColor(Color.gray);
            countImage.SetActive(false);
        }
        else
        {
            // Otherwise, set the color to yellow, update the count text, and show the count image.
            SetColor(Color.yellow);
            countText.text = count.ToString();
            countImage.SetActive(true);
        }
    }

    // Handle left click events on the PhonemeKey.
    public override void OnLeftClick()
    {
        // Play the associated audio clip.
        PlayAudio();

        // Check if the current view is DeductionView because the PhonemeKey count is only manipulated in this view.
        if (ViewManager.CheckCurrentView<DeductionView>())
        {
            // Subtract the count of the phoneme. If the count is less than 0, return early.
            if (phoneme.SubtractCount() < 0) return;

            // Enter the phoneme key into the answer key manager.
            PhonemeKeyManager.instance.EnterAnswerkey(this);

            // Update the visual representation of the phoneme count.
            UpdateCountVisual();
        }
    }

    // Add to the phoneme count and update the visual representation.
    public void AddCount()
    {
        // Play the associated audio clip.
        PlayAudio();

        // Add to the phoneme count.
        phoneme.AddCount();

        // Update the visual representation of the phoneme count.
        UpdateCountVisual();
    }

    // Add to the phoneme count without playing audio and update the visual representation.
    public void AddCountWithoutAudio()
    {
        // Add to the phoneme count.
        phoneme.AddCount();

        // Update the visual representation of the phoneme count.
        UpdateCountVisual();
    }
}