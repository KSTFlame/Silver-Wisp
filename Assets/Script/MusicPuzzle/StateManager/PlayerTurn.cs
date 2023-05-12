using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(StateManager sm) : base(sm)
    {
        nameOfState = Constants.STATE_PlayerTurn;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Enter PlayerTurn");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Update PlayerTurn");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Exit PlayerTurn");
    }
}
