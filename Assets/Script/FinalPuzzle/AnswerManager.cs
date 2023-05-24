using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public ListOfAnswers Answers;
    public DialogueManager DialogueManager;
    private bool[] m_Verified;

    private void Start()
    {
        m_Verified = new bool[Answers.QuestionAnswer.Count];
    }

    public void CheckAnswer(string input)
    {
        if(Answers.QuestionAnswer[DialogueManager.ActualDialogue - 1] == input)
        {
            m_Verified[DialogueManager.ActualDialogue - 1] = true;
        }
    }
}
