using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct DialogueBeat
{
    public List<DialogueLine> dialogueLines;
    public string characterName;
}

[System.Serializable]
public struct DialogueLine
{
    public bool isRead;
    public string line;
    public bool isAnswer;
    public string answerString;
    public bool isAnswerSolved;
}

[System.Serializable]

public class DialogueSequence : MonoBehaviour
{
    public AnswerKeyManager answerKeyManager;
    public DialogueLine currentDialogueLine;
    public bool sequencePlayed = false;
    [SerializeField] List<DialogueBeat> dialogueBeats;
    [SerializeField] bool playOnStart;
    private UnlockedClue unlockedClue;
    int beatCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (playOnStart)
        {
            StartSequence();
        }
    }
    public void StartSequence()
    {

        if (dialogueBeats.Count > 0)
        {
            StartCoroutine(PlayBeat());
        }
    }

    public void StartSequence(UnlockedClue u)
    {
        unlockedClue = u;

        if (dialogueBeats.Count > 0)
        {
            StartCoroutine(PlayBeat());
        }
    }


    IEnumerator PlayBeat()
    {
        DialogueView dialogueView = ViewManager.GetView<DialogueView>();
        dialogueView.SetSpeaker(dialogueBeats[beatCount].characterName);
        Debug.Log("Character Name: " + dialogueBeats[beatCount].characterName);

        int dialogueLineCount = dialogueBeats[beatCount].dialogueLines.Count;

        for (int i = 0; i < dialogueLineCount; i++)
        {
            currentDialogueLine = dialogueBeats[beatCount].dialogueLines[i];
            dialogueView.SpeakDialogue(currentDialogueLine.line);
            ViewManager.ShowView<DialogueView>();
            // while(!dialogueLine.isRead)
            // {
            //     yield return null;
            // }
            //Commented for when user controls dialogue pace
            yield return new WaitForSeconds(2f);
            if(currentDialogueLine.isAnswer)
            {
                PhonemeKeyManager.instance.SetAnswerKeyManager(answerKeyManager);
                PhonemeKeyManager.instance.SetCurrentDialogueSequence(this);
                ViewManager.ShowView<DeductionView>();
                answerKeyManager.Initialize(currentDialogueLine.answerString);
                while(!currentDialogueLine.isAnswerSolved)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(1f);
            } 
        }

        beatCount++;

        if (beatCount < dialogueBeats.Count)
        {
            StartCoroutine(PlayBeat());
        }
        else{
            beatCount = 0;
            sequencePlayed = true;
            if(unlockedClue != null) unlockedClue.playerHasInteracted = true;
            ViewManager.ShowView<NullView>();
        }
    }
}


