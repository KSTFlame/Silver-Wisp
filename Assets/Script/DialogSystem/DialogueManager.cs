using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI m_Dialogue;
    public Queue<string> m_Sentences;
    public bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        m_Sentences = new Queue<string>();
        isTalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        m_Sentences.Clear();

        foreach(string sentence in dialogue.m_Sentences)
        {
            m_Sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(m_Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = m_Sentences.Dequeue();
        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        m_Dialogue.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            m_Dialogue.text += letter;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("DialogueEnded");
        isTalking = false;
    }
}
