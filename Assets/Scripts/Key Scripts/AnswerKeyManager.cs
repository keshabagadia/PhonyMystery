using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerKeyManager : MonoBehaviour
{
    [SerializeField] private GameObject answerKeyPrefab;
    [SerializeField] private Transform answerKeyParent;
    public List<AnswerKey> answerKeys;
    [SerializeField] private string answerString;
    [SerializeField] private WordData wordData;

    public void Initialize(string answer)
    {
        answerString = answer;
        Initialize();
    }

    public void Initialize()
    {
        ClearAnswerKeys();
        answerKeys = new List<AnswerKey>();
        SpawnAnswerKeys();
    }

    private void ClearAnswerKeys()
    {
        foreach(AnswerKey answerKey in answerKeys)
        {
            Destroy(answerKey.gameObject);
        }
        answerKeys.Clear();
    }

    private void SpawnAnswerKeys()
    {
        Word word = wordData.FindWord(answerString);
        foreach(string phonemeString in word.phonemeStrings)
        {
            AnswerKey answerKey = Instantiate(answerKeyPrefab, answerKeyParent).GetComponent<AnswerKey>();
            answerKey.Initialize(PhonemeKeyManager.instance.FindPhonemeKey(phonemeString).phoneme);
            answerKeys.Add(answerKey);
        }
    }

    public void SubmitAnswer()
    {
        bool allCorrect = true;
        foreach(AnswerKey a in answerKeys)
        {
            allCorrect= allCorrect&&a.CheckAnswer();
        }
        if(allCorrect)
        {
            Debug.Log("Correct Answer");
        } else
        {
            Debug.Log("Incorrect Answer");
        }
    }

}
