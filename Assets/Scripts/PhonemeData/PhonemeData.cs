using System.Collections.Generic;
using UnityEngine;

// This script defines a ScriptableObject that holds a list of phonemes.
// It can be created from the Unity editor menu under "ScriptableObjects/PhonemeData". 
//The one used by the project is located at "Assets/PhonemeData/PhonemeData.asset".
[CreateAssetMenu(fileName = "PhonemeData", menuName = "ScriptableObjects/PhonemeData", order = 1)]
public class PhonemeData : ScriptableObject
{
    // List of phonemes that this ScriptableObject will store.
    public List<Phoneme> phonemes;
}