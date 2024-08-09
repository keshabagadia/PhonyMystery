using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the answer keys in the game.
//Every instance is responsible for managing a set of answer keys corresponding to a single clue answer string.
public class AnswerKeyManager : MonoBehaviour
{
    // Prefab for creating answer keys.
    [SerializeField]
    private GameObject answerKeyPrefab;

    // Parent transform for spanswer keys.
    [SerializeField]
    private Transform answerKeyParent;

    // List to store all the answer keys related to the answer string.
    public List<AnswerKey> answerKeys;

    // The correct answer string.
    [SerializeField]
    private string answerString;

    // Reference to the WordData for finding words.
    [SerializeField]
    private WordData wordData;

    // Initialize the AnswerKeyManager with a specific answer string.
    public void Initialize(string answer)
    {
        answerString = answer;
        Initialize();
    }

    // Initialize the AnswerKeyManager when an answer string is already set.
    public void Initialize()
    {
        // Clear existing answer keys.
        ClearAnswerKeys();

        // Initialize the list of answer keys.
        answerKeys = new List<AnswerKey>();

        // Spawn new answer keys based on the answer string.
        SpawnAnswerKeys();
    }

    // Clear all existing answer keys.
    //This may not be necessary if there is a new answer key manager instance for each clue.
    private void ClearAnswerKeys()
    {
        // Destroy each answer key GameObject.
        foreach (AnswerKey answerKey in answerKeys)
        {
            Destroy(answerKey.gameObject);
        }

        // Clear the list of answer keys.
        answerKeys.Clear();
    }

    // Spawn new answer keys based on the answer string.
    private void SpawnAnswerKeys()
    {
        // Find the word corresponding to the answer string from the preset word data.
        Word word = wordData.FindWord(answerString);

        // Create an answer key for each phoneme in the word.
        foreach (string phonemeString in word.phonemeStrings)
        {
            // Instantiate a new answer key from the prefab.
            AnswerKey answerKey = Instantiate(answerKeyPrefab, answerKeyParent)
                .GetComponent<AnswerKey>();

            // Initialize the answer key with the corresponding phoneme.
            answerKey.Initialize(PhonemeKeyManager.instance.FindPhonemeKey(phonemeString).phoneme);

            // Add the answer key to the list.
            answerKeys.Add(answerKey);
        }
    }
}
