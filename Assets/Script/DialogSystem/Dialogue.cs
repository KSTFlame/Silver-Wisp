using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI m_Text;
    public string[] m_Lines;
    public float m_TextSpeed;

    private int m_index;

    // Start is called before the first frame update
    void Start()
    {
        m_Text.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (m_index < m_Lines.Length - 1)
        {
            m_index++;
            m_Text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
            gameObject.SetActive(false);
    }

    IEnumerator TypeLine()
    {
        foreach(char c in m_Lines[m_index].ToCharArray())
        {
            m_Text.text += c;
            yield return new WaitForSeconds(m_TextSpeed);
        }
    }
}
