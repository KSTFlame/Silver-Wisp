using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSequence : State
{
    public MusicSequence(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_MusicSequence;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Enter MusicSequnce");

        stateManager.m_nRoundText.text = "Round " + stateManager.m_nRound + " / 5";

        if(stateManager.m_CorrectSequence)    
            stateManager.StartCoroutine(stateManager.MusicalNoteSpawn());
        else
            stateManager.StartCoroutine(stateManager.MusicalNoteRepeat());
    }
}
