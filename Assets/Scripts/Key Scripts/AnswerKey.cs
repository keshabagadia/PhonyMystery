using UnityEngine;

public class AnswerKey : Key
{
    [SerializeField]private Phoneme answerPhoneme;
    public Phoneme currentPhoneme;
    private bool isCorrect;
    public void Initialize(Phoneme p)
    {
        answerPhoneme = p;
        Initialize();
    }

    public override void Initialize()
    {
        displayText.text = "?";
        SetColor(Color.white);
        currentPhoneme = new Phoneme();
        
    }

    public void SetCurrentPhoneme(Phoneme p)
    {
        currentPhoneme = p;
        displayText.text = p.phonemeString;
        audioSource.clip = p.audioClip;
    }

    public void ClearPhoneme()
    {
        Initialize();
    }

    public bool CheckAnswer()
    {
        if(currentPhoneme == answerPhoneme)
        {
            SetColor(Color.green);
            isCorrect = true;
        } else {
            Debug.Log(currentPhoneme.phonemeString + " is not equal to " + answerPhoneme.phonemeString);
            SetColor(Color.red);
            isCorrect = false;
        }
        return isCorrect;
    }
}