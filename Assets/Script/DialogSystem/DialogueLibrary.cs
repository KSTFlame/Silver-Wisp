using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLibrary : MonoBehaviour
{

    public static int m_DialogueIndex = 0; //What Dialogue we need to show to the user
    public static int m_SpeakerIndex = 0; //What person is speaking at the moment
    public static string[] m_Lines = new string[10];
    public static string m_Speaker;

    public void Update()
    {
        ActiveDialogue();
    }

    public void ActiveDialogue()
    {
        switch (m_DialogueIndex)
        {
            case 0:
                if(m_SpeakerIndex == 0)
                    m_Speaker = "Pippo";
                m_Lines[0] = "Ciao a tutti i compagni di viaggio di questo incredibile mondo e in questa grande avventura";
                
                if (m_SpeakerIndex == 1)
                    m_Speaker = "Topolino";
                m_Lines[1] = "Boia deh peff�";

                break;
            case 1:
                if (m_SpeakerIndex == 0)
                    m_Speaker = "Giorgio";
                m_Lines[0] = "Dialogo Numero 2";
                if (m_SpeakerIndex == 1)
                    m_Speaker = "Paperino";
                m_Lines[1] = "Babba bia";
                break;
            default:
                m_Lines[0] = "Ciao a tutti";
                m_Lines[1] = "Boia deh peff�";
                break;
        }
    }
}
