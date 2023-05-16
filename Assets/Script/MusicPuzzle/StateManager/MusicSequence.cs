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

        if (stateManager.m_CorrectSequence == false)
            stateManager.m_LifePoints--;
        if (stateManager.m_LifePoints <= 0)
        {
            Debug.Log("Hai Perso");
        }

        if (stateManager.m_CorrectSequence)    
            stateManager.StartCoroutine(stateManager.MusicalNoteSpawn());
        else
        {
            stateManager.StartCoroutine(stateManager.MusicalNoteRepeat());
        }
    }
}
