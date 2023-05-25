using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelManager : MonoBehaviour
{
    public GameObject[] disks;
    public Quaternion solveRotation;

    /// <summary>
    /// Check if all disks are in right position
    /// </summary>
    /// <returns>true if the game is complete</returns>
    public bool IsSolved()
    {
        for (int i = 1; i < disks.Length; i++)
        {
            if (Mathf.RoundToInt(disks[i].transform.localRotation.y) != solveRotation.y)
            {
                return false;
            }
        }
        return true;
    }

    /*Solo per test da cancellare e creare un vero sistema di vittoria*/
    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if (IsSolved())
            {
                Debug.Log("Vittoria");
            }
            else Debug.Log("Da completare");
        }        
    }


}
