using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State
{

    int i;

    public PlayerTurn(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_PlayerTurn;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        i = 0;
        Debug.Log("Enter PlayerTurn");
        Debug.Log(""+stateManager.m_arrowList.Count);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Update PlayerTurn: " + i);
        if(Input.GetKeyDown(KeyCode.DownArrow) && stateManager.m_arrowList[i] == "downArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("InputCorretto");
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && stateManager.m_arrowList[i] != "downArrow")
        {
            Debug.Log("Errore");
            stateManager.m_CorrectSequence = false;
            stateManager.ChangeState(Constants.STATE_MusicSequence);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && stateManager.m_arrowList[i] == "upArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("InputCorretto");
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && stateManager.m_arrowList[i] != "upArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("Errore");
            stateManager.m_CorrectSequence = false;
            stateManager.ChangeState(Constants.STATE_MusicSequence);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && stateManager.m_arrowList[i] == "leftArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("InputCorretto");
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && stateManager.m_arrowList[i] != "leftArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("Errore");
            stateManager.m_CorrectSequence = false;
            stateManager.ChangeState(Constants.STATE_MusicSequence);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && stateManager.m_arrowList[i] == "rightArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("InputCorretto");
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && stateManager.m_arrowList[i] == "rightArrow")
        {
            //Stampa a schermo l'input
            Debug.Log("Errore");
            stateManager.m_CorrectSequence = false;
            stateManager.ChangeState(Constants.STATE_MusicSequence);
        }

        if(stateManager.m_arrowList.Count == i)
        {
            stateManager.m_CorrectSequence = true;
            stateManager.m_arrowList.Clear();
            stateManager.m_nRound++;
            stateManager.m_nRoundText.text = "Round " + stateManager.m_nRound + " / "+ stateManager.m_MaxNumberOfRound;
            if (stateManager.m_MaxNumberOfRound == stateManager.m_nRound)
            {
                //stateManager.ChangeState(Constants.STATE_WinningState);
                Debug.Log("GG");
            }  
            else
                stateManager.ChangeState(Constants.STATE_MusicSequence);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exit PlayerTurn");
    }
}
