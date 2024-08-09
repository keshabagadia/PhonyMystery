using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PhonemeKeyManager : MonoBehaviour
{
    [SerializeField] private GameObject phonemeKeyPrefab;
    [SerializeField] private Transform phonemeKeyRowParent;
    public PhonemeData phonemeData;
    public List<PhonemeKey> scenePhonemeKeys;
    [SerializeField]private Stack<PhonemeKey> clickedPhonemeStack;
    private AnswerKeyManager answerKeyManager;
    private DialogueSequence currentDialogueSequence;

    public static PhonemeKeyManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scenePhonemeKeys = new List<PhonemeKey>();
        clickedPhonemeStack = new Stack<PhonemeKey>();
        SpawnPhonemeKeysUnderColumns(3);
    }  
    
    private void SpawnPhonemeKeysUnderColumns(int phonemesInEachColumn)
    {
        //retrieve columns from row parent
        List<Transform> columns = new List<Transform>();
        foreach (Transform child in phonemeKeyRowParent)
        {
            columns.Add(child);
        }

        //instantiate phoneme keys in each column
        if (phonemeData == null || phonemeData.phonemes.Count == 0)
        {
            Debug.LogError("PhonemeData is not assigned or empty.");
            return;
        }
        int phonemeIndex = 0;
        if(phonemeIndex<phonemeData.phonemes.Count)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                for (int j = 0; j < phonemesInEachColumn; j++)
                {
                    phonemeData.phonemes[phonemeIndex].Initialize();
                    PhonemeKey phonemeKey = Instantiate(phonemeKeyPrefab, columns[i]).GetComponent<PhonemeKey>();
                    phonemeKey.Initialize(phonemeData.phonemes[phonemeIndex]);
                    scenePhonemeKeys.Add(phonemeKey);
                    phonemeIndex++;
                    if(phonemeIndex>=phonemeData.phonemes.Count)
                    {
                        break;
                    }
                }
            }
        }
    }

    public void ClearClickedPhonemeStack()
    {
        StartCoroutine(ClearPhonemeStack());
    }

    public void SetAnswerKeyManager(AnswerKeyManager a)
    {
        answerKeyManager = a;
    }

    public void SetCurrentDialogueSequence(DialogueSequence dialogueSequence)
    {
        currentDialogueSequence = dialogueSequence;
    }

    public PhonemeKey FindPhonemeKey(string phonemeString)
    {
        foreach (PhonemeKey phonemeKey in scenePhonemeKeys)
        {
            if (phonemeKey.name == phonemeString)
            {
                return phonemeKey;
            }
        }
        Debug.Log("PhonemeKey not found");
        return null;
    }

    public void EnterAnswerkey(PhonemeKey phonemeKey)
    {
        clickedPhonemeStack.Push(phonemeKey);
        answerKeyManager.answerKeys[clickedPhonemeStack.Count - 1].SetCurrentPhoneme(phonemeKey.phoneme);
    }

    public bool BackspaceAnswerKey()
    {
        if (clickedPhonemeStack.Count > 0)
        {
            PhonemeKey phonemeKey = clickedPhonemeStack.Pop();
            Debug.Log("Popped: " + phonemeKey.name);    
            phonemeKey.AddCountWithoutAudio();
            answerKeyManager.answerKeys[clickedPhonemeStack.Count].ClearPhoneme();
            return true;
        }
        else return false;
    }

    public void SubmitAnswer()
    {
        bool allCorrect = true;
        foreach(AnswerKey answerKey in answerKeyManager.answerKeys)
        {
            bool isCorrect = answerKey.CheckAnswer();
            allCorrect = allCorrect && isCorrect;
        }
        if(allCorrect)
        {
            currentDialogueSequence.currentDialogueLine.isAnswerSolved = true;
            Debug.Log("Correct Answer");
        } else
        {
            Debug.Log("Incorrect Answer");
        }
    }

    IEnumerator ClearPhonemeStack()
    {
        while(BackspaceAnswerKey())
        {
            Debug.Log("Clearing stack");
            yield return null;
        }
        // for(int i=0; i<clickedPhonemeStack.Count; i++)
        // {
        //     BackspaceAnswerKey();
        //     yield return null;
        // }
    }
}