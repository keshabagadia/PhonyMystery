using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordData", menuName = "ScriptableObjects/WordData", order = 2)]
public class WordData : ScriptableObject
{
    public List<Word> words;
    
    public Word FindWord(string wordString)
    {
        foreach(Word word in words)
        {
            if(word.wordString == wordString)
            {
                return word;
            }
        }
        
        Debug.Log("Word not found" + wordString);
        return null;
    }
}