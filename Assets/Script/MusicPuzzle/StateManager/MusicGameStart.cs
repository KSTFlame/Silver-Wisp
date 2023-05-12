using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameStart : State
{
    public MusicGameStart(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_MusicGameStart;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Enter MusicGameStart");
        Debug.Log("Messaggio a schermo della sfida");
        //DialogueLibrary.m_DialogueIndex = 1;
        //StateManager.m_StaticDialogueBox.SetActive(true);
    }
 
    public override void OnUpdate()
    {
        base.OnUpdate();
        //Debug.Log("Update MusicGameStart");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exit MusicGameStart");
    }
}
