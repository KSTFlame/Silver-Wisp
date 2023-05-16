using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public Dictionary<string, State> listOfStates = new Dictionary<string, State>();

    //MusicGameStart State
    //public GameObject m_DialogueBox;
    //public static GameObject m_StaticDialogueBox;

    //MusicSequence State
    public GameObject m_SpawnPoint;
    public GameObject m_PrefabUpArrow;
    public GameObject m_PrefabDownArrow;
    public GameObject m_PrefabLeftArrow;
    public GameObject m_PrefabRightArrow;
    private bool m_isSpawning;
    public List<string> m_arrowList;
    public bool m_CorrectSequence;
    public int m_nNotes;
    public int m_nRound;
    public TextMeshProUGUI m_nRoundText;

    public void SetupStates()
    {
        listOfStates.Add(Constants.STATE_MusicSequence, new MusicSequence(this));
        listOfStates.Add(Constants.STATE_PlayerTurn, new PlayerTurn(this));
        listOfStates.Add(Constants.STATE_MusicGameStart, new MusicGameStart(this));
    }

    void Awake()
    {
        SetupStates();
        //m_StaticDialogueBox = m_DialogueBox;
        ChangeState(Constants.STATE_MusicGameStart);
    }

    void Update()
    {
        currentState.OnUpdate();

        if(currentState.nameOfState == Constants.STATE_MusicGameStart)
        {
            //if (m_DialogueBox.activeSelf == false)
                ChangeState(Constants.STATE_MusicSequence);
        }

        if (!m_isSpawning)
        {
            ChangeState(Constants.STATE_PlayerTurn);
        }

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeState(Constants.STATE_PlayerTurn);
        }*/
    }

    public void ChangeState(string key)
    {
        if (currentState.nameOfState == key) return;
        currentState?.OnExit();
        currentState = listOfStates[key];
        currentState?.OnEnter();
    }

    public IEnumerator MusicalNoteSpawn()
    {
        for(int i = 0; i < m_nNotes+m_nRound; i++)
        {
            int rand = UnityEngine.Random.Range(0,4);
            m_isSpawning = true;
            switch (rand)
            {
                case 0:
                    Instantiate(m_PrefabUpArrow, m_SpawnPoint.transform.position, Quaternion.identity);
                    m_arrowList.Add("upArrow");
                    break;
                case 1:
                    Instantiate(m_PrefabRightArrow, m_SpawnPoint.transform.position, Quaternion.identity);
                    m_arrowList.Add("rightArrow");
                    break;
                case 2:
                    Instantiate(m_PrefabLeftArrow, m_SpawnPoint.transform.position, Quaternion.identity);
                    m_arrowList.Add("leftArrow");
                    break;
                case 3:
                    Instantiate(m_PrefabDownArrow, m_SpawnPoint.transform.position, Quaternion.identity);
                    m_arrowList.Add("downArrow");
                    break;
                default:
                    Instantiate(m_PrefabUpArrow, m_SpawnPoint.transform.position, Quaternion.identity);
                    m_arrowList.Add("upArrow");
                    break;
            }
            Debug.Log("Rand Value: " + rand);
            yield return new WaitForSeconds(0.5f);
            m_isSpawning = false;
        }
    }

    public IEnumerator MusicalNoteRepeat()
    {
        for (int i = 0; i < m_nNotes + m_nRound; i++)
        {
            m_isSpawning = true;
            if(m_arrowList[i] == "downArrow")
                Instantiate(m_PrefabDownArrow, m_SpawnPoint.transform.position, Quaternion.identity);
            else if (m_arrowList[i] == "upArrow")
                Instantiate(m_PrefabUpArrow, m_SpawnPoint.transform.position, Quaternion.identity);
            else if(m_arrowList[i] == "leftArrow")
                Instantiate(m_PrefabLeftArrow, m_SpawnPoint.transform.position, Quaternion.identity);
            else if(m_arrowList[i] == "rightArrow")
                Instantiate(m_PrefabRightArrow, m_SpawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            m_isSpawning = false;
        }

    }
}