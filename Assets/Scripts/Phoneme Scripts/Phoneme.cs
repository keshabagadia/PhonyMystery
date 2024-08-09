using UnityEngine;

[System.Serializable]
public class Phoneme
{
    public string phonemeString;
    public AudioClip audioClip;
    public int phonemeCount;

    public void Initialize()
    {
        phonemeCount = 0;
        if(string.IsNullOrEmpty(phonemeString))
        {
            phonemeString = audioClip.name;
        }
    }
    public int AddCount()
    {
        phonemeCount++;
        return phonemeCount;
    }
    public int SubtractCount()
    {
        if(phonemeCount>0) return phonemeCount--;
        else return -1;
    }
}