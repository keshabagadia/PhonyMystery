using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    public string clueString;
    [SerializeField] Word clueWord;
    [SerializeField] WordData wordData;
    [SerializeField] List<PhonemeKey> correspondingPhonemeKeys;
    void Start()
    {
        clueWord = wordData.FindWord(clueString.Trim().ToLower());
        FindCorrespondingPhonemeKeys();
    }

    void FindCorrespondingPhonemeKeys(){
        string[] phonemeStrings = clueWord.phonemeStrings;
        foreach(string phonemeString in phonemeStrings){
           correspondingPhonemeKeys.Add(PhonemeKeyManager.instance.FindPhonemeKey(phonemeString));
        }
    }
    public void AddPhonemeCount(){
        StartCoroutine(AddPhonemes());
    }

    IEnumerator AddPhonemes(){
        ViewManager.ShowView<InventoryView>();
        foreach(PhonemeKey phonemeKey in correspondingPhonemeKeys){
            phonemeKey.AddCount();
            Debug.Log("phoneme keys being parsed");
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("phoneme keys parsed");
        ViewManager.ShowPreviousView();
    }
}
