using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnswerKeySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnswerKeyManager answerKeyManager = GetComponent<AnswerKeyManager>();
        answerKeyManager.Initialize("bed");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
