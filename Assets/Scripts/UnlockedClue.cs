
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class UnlockedClue : Interactable
{
    public bool playerHasInteracted = false;
    [SerializeField] DialogueSequence postInteractionDialogue;
    public string clueString;
    [SerializeField] Word clueWord;
    [SerializeField] WordData wordData;
    [SerializeField] List<PhonemeKey> correspondingPhonemeKeys;
    public void Start()
    {
        //base.Start();
        clueWord = wordData.FindWord(clueString.Trim().ToLower());
        FindCorrespondingPhonemeKeys();
    }

    void FindCorrespondingPhonemeKeys(){
        string[] phonemeStrings = clueWord.phonemeStrings;
        foreach(string phonemeString in phonemeStrings){
           correspondingPhonemeKeys.Add(PhonemeKeyManager.instance.FindPhonemeKey(phonemeString));
        }
    }
    public void Interact(bool isQuestion)
    {
        if(!playerHasInteracted){
            Debug.Log("Interacting with unlocked clue" + playerHasInteracted + clueString);
            if(!isQuestion){
                StartCoroutine(AddPhonemesAndPlayDialogue());
            } else {
                StartDialogue();
            }
        } else {
            postInteractionDialogue.StartSequence();
        }
    }

    public override void Interact()
    {
        Interact(true);
    }

    public override void StartDialogue()
    {
        dialogueSequence.StartSequence(this);
    }

    IEnumerator AddPhonemesAndPlayDialogue(){
        ViewManager.ShowView<InventoryView>();
        foreach(PhonemeKey phonemeKey in correspondingPhonemeKeys){
            phonemeKey.AddCount();
            yield return new WaitForSeconds(1f);
        }
        StartDialogue();
    }
}
