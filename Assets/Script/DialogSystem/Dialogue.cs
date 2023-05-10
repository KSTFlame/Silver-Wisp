using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI m_Text;
    public TextMeshProUGUI m_SpeakerText;

    public string[] m_Lines;
    public float m_TextSpeed;


    private int m_index;

    public void Start()
    {
        for (int i = 0; i < m_Lines.Length; i++)
            m_Lines[i] = null;
    }

    // Update is called once per frame
    void Update()
    {
        m_SpeakerText.text = DialogueLibrary.m_Speaker;

        if (m_Lines[m_index] == null)
            NextLine();
        if (Input.GetMouseButtonDown(0))
        {
            if(m_Text.text == m_Lines[m_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                m_Text.text = m_Lines[m_index];
            }
        }
    }

    public void StartDialogue()
    {
        m_index = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        DialogueLibrary.m_SpeakerIndex++;

        if (m_index < m_Lines.Length - 1 && m_Lines[m_index+1] != null)
        {
            m_index++;
            m_Text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < m_Lines.Length; i++)
        {
            m_Lines = DialogueLibrary.m_Lines;
            Debug.Log("" + m_Lines[i]);
        }

        m_SpeakerText.text = DialogueLibrary.m_Speaker;
        m_Text.text = string.Empty;
        StartDialogue();
    }

    private void OnDisable()
    {
        DialogueLibrary.m_DialogueIndex++;
        DialogueLibrary.m_SpeakerIndex = 0;
        Debug.Log(DialogueLibrary.m_DialogueIndex);
    }

    IEnumerator TypeLine()
    {
        if(m_Lines != null)
        foreach(char c in m_Lines[m_index].ToCharArray())
        {
            m_Text.text += c;
            yield return new WaitForSeconds(m_TextSpeed);
        }
    }
}
