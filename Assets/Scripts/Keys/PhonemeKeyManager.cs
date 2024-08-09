using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Manages phoneme keys in the game.
public class PhonemeKeyManager : MonoBehaviour
{
    // Prefab for creating phoneme keys.
    [SerializeField] private GameObject phonemeKeyPrefab;

    // Parent transform for phoneme key instantiation.
    [SerializeField] private Transform phonemeKeyRowParent;

    // Scriptable object containing all phonemes.
    public PhonemeData phonemeData;

    // List to store all phoneme keys in the scene.
    public List<PhonemeKey> scenePhonemeKeys;

    // Stack to keep track of clicked phoneme keys during deduction view.
    [SerializeField] private Stack<PhonemeKey> clickedPhonemeStack;

    // Reference to the current AnswerKeyManager.
    private AnswerKeyManager answerKeyManager;

    // Reference to the current dialogue sequence.
    private DialogueSequence currentDialogueSequence;

    // Singleton instance of PhonemeKeyManager.
    public static PhonemeKeyManager instance { get; private set; }

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Ensure that there is only one instance of PhonemeKeyManager.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the list and stack.
        scenePhonemeKeys = new List<PhonemeKey>();
        clickedPhonemeStack = new Stack<PhonemeKey>();

        // Spawn phoneme keys under columns.
        SpawnPhonemeKeysInColumns(3);
    }

    // Spawn phoneme keys under specified columns.
    private void SpawnPhonemeKeysInColumns(int phonemesInEachColumn)
    {
        // Retrieve columns from the row parent.
        List<Transform> columns = new List<Transform>();
        foreach (Transform child in phonemeKeyRowParent)
        {
            columns.Add(child);
        }
        // Check if phoneme data is assigned and not empty.
        if (phonemeData == null || phonemeData.phonemes.Count == 0)
        {
            Debug.LogError("PhonemeData is not assigned or empty.");
            return;
        }

        // Instantiate phoneme keys in each column.
        //The pointer is used to iterate through the phoneme list.
        int phonemeIndexPtr = 0;
        
        // Ensure there are phonemes to initialize.
        if (phonemeIndexPtr < phonemeData.phonemes.Count)
        {
            // Iterate through each column.
            for (int i = 0; i < columns.Count; i++)
            {
                // Iterate through each slot in the column.
                for (int j = 0; j < phonemesInEachColumn; j++)
                {
                    // Initialize the phoneme data.
                    phonemeData.phonemes[phonemeIndexPtr].Initialize();
                    // Instantiate a new phoneme key from the prefab and set it up.
                    PhonemeKey phonemeKey = Instantiate(phonemeKeyPrefab, columns[i]).GetComponent<PhonemeKey>();
                    phonemeKey.Initialize(phonemeData.phonemes[phonemeIndexPtr]);
                    // Add the phoneme key to the list of scene phoneme keys.
                    scenePhonemeKeys.Add(phonemeKey);
                    // Move to the next phoneme.
                    phonemeIndexPtr++;
                    // Break the loop if all phonemes have been initialized.
                    if (phonemeIndexPtr >= phonemeData.phonemes.Count)
                    {
                        break;
                    }
                }
            }
        }
    }

    // Clear the stack of clicked phoneme keys.
    public void ClearClickedPhonemeStack()
    {
        StartCoroutine(ClearPhonemeStack());
    }

    // Set the AnswerKeyManager reference.
    public void SetAnswerKeyManager(AnswerKeyManager a)
    {
        answerKeyManager = a;
    }

    // Set the current dialogue sequence.
    public void SetCurrentDialogueSequence(DialogueSequence dialogueSequence)
    {
        currentDialogueSequence = dialogueSequence;
    }

    // Find a phoneme key by its string representation.
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

    // Enter a phoneme key into the answer key.
    public void EnterAnswerkey(PhonemeKey phonemeKey)
    {
        clickedPhonemeStack.Push(phonemeKey);
        answerKeyManager.answerKeys[clickedPhonemeStack.Count - 1].SetCurrentPhoneme(phonemeKey.phoneme);
    }

    // Remove the last entered phoneme key from the answer key using the clicked phoneme keys stack.
    // Remove the last entered phoneme key from the answer key.
    public bool BackspaceAnswerKey()
    {
        // Check if there are any phoneme keys in the stack.
        if (clickedPhonemeStack.Count > 0)
        {
            // Pop the last phoneme key from the stack.
            PhonemeKey phonemeKey = clickedPhonemeStack.Pop();
    
            // Increment the count of the phoneme key without playing audio.
            phonemeKey.AddCountWithoutAudio();
    
            // Clear the corresponding answer key.
            answerKeyManager.answerKeys[clickedPhonemeStack.Count].ClearPhoneme();
    
            return true;
        }
        else
        {
            return false;
        }
    }

    // Submit the answer and check if all answer keys are correct.
    public void SubmitAnswer()
    {
        // Flag to track if all answers are correct.
        bool allCorrect = true;
    
        // Iterate through each answer key and check if the answer is correct.
        foreach (AnswerKey answerKey in answerKeyManager.answerKeys)
        {
            bool isCorrect = answerKey.CheckAnswer();
            allCorrect = allCorrect && isCorrect;
        }
    
        // If all answers are correct, mark the current dialogue line as solved.
        if (allCorrect)
        {
            currentDialogueSequence.currentDialogueLine.isAnswerSolved = true;
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Incorrect Answer");
        }
    }

    // Coroutine to clear the stack of clicked phoneme keys.
    IEnumerator ClearPhonemeStack()
    {
        while (BackspaceAnswerKey())
        {
            yield return null;
        }
    }
}