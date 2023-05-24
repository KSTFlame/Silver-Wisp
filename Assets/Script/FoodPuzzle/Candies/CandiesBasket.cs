﻿using System;
using UnityEngine;

public class CandiesBasket : MonoBehaviour
{
    [SerializeField, Min(0), Header("Candies")]
    private int _candiesToReach = 10;
    [SerializeField, Min(0)]
    private int _missableCandies = 2;

    private int _currentCatchedCandies = 0;
    private int _missedCandies = 0;

    public event Action OnCandiesReached;
    public event Action OnCandiesMissed;

    public void CatchCandy(int catchedCandies)
    {
        _currentCatchedCandies += catchedCandies;

        if (_currentCatchedCandies >= _candiesToReach)
        {
            _currentCatchedCandies = _candiesToReach;
            OnCandiesReached?.Invoke();
        }
    }

    public void MissCandy()
    {
        _missedCandies++;

        if (_missedCandies >= _missableCandies)
        {
            OnCandiesMissed?.Invoke();
        }
    }
}