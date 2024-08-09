using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhonemeData", menuName = "ScriptableObjects/PhonemeData", order = 1)]
public class PhonemeData : ScriptableObject
{
    public List<Phoneme> phonemes;
}