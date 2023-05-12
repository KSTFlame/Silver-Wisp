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
        stateManager.StartCoroutine(stateManager.MusicalNoteSpawn());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Update MusicSequnce");

    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exit MusicSequence");
    }
}
