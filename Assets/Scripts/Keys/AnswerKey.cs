using UnityEngine;

// AnswerKey class is used to manage the answer keys in the game for the deduction minigame.
public class AnswerKey : Key
{
    // The correct phoneme that this answer key should match.
    [SerializeField] private Phoneme answerPhoneme;

    // The current phoneme displayed by this answer key. When "?" is displayed, the current phoneme is either null or not set.
    public Phoneme currentPhoneme;

    // Flag to indicate if the current phoneme is correct.
    private bool isCorrect;

    // Initialize the answer key with a specific phoneme.
    public void Initialize(Phoneme p)
    {
        answerPhoneme = p;
        Initialize();
    }

    // Override the base Initialize method to set up the answer key.
    public override void Initialize()
    {
        // Display a question mark as the initial text.
        displayText.text = "?";

        // Set the initial color to white.
        SetColor(Color.white);

        // Initialize the current phoneme to a new phoneme.
        currentPhoneme = new Phoneme();
    }

    // Set the current phoneme and update the display text and audio clip.
    public void SetCurrentPhoneme(Phoneme p)
    {
        currentPhoneme = p;
        displayText.text = p.phonemeString;
        audioSource.clip = p.audioClip;
    }

    // Clear the current phoneme and reinitialize the answer key.
    public void ClearPhoneme()
    {
        Initialize();
    }

    // Check if the current phoneme matches the answer phoneme.
    public bool CheckAnswer()
    {
        if (currentPhoneme == answerPhoneme)
        {
            // Set the color to green if the answer is correct.
            SetColor(Color.green);
            isCorrect = true;
        }
        else
        {
            // Log the mismatch and set the color to red if the answer is incorrect.
            Debug.Log(currentPhoneme.phonemeString + " is not equal to " + answerPhoneme.phonemeString);
            SetColor(Color.red);
            isCorrect = false;
        }
        return isCorrect;
    }
}