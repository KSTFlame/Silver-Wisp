using System;
using UnityEngine;

public class CandiesGenerator : ObjectItemsSpawner
{
    [System.Serializable]
    public class VectorRange
    {
        public Vector3 Min;
        public Vector3 Max;

        public Vector3 RandomVectorBetween()
        {
            return new Vector3(UnityEngine.Random.Range(Min.x, Max.x), UnityEngine.Random.Range(Min.y, Max.y), UnityEngine.Random.Range(Min.z, Max.z));
        }
    }

    [SerializeField, Header("Candies")]
    private uint _candiesToReach = 10;
    [SerializeField]
    private uint _missableCandies = 2;
    [SerializeField]
    private VectorRange _range;

    private uint _currentCatchedCandies = 0;
    private uint _missedCandies = 0;

    public event Action OnCandiesReached;
    public event Action OnCandiesMissed;

    private void Start()
    {
        StartSpawnerRoutine();
    }

    public void CatchCandy()
    {
        _currentCatchedCandies++;

        if (_currentCatchedCandies >= _candiesToReach)
        {
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

    protected override GameObject SpawnObject()
    {
        GameObject candyGO = base.SpawnObject();

        if (candyGO.TryGetComponent(out Candy candy))
        {
            candy.Init(Pool, this);
            candy.transform.position = _range.RandomVectorBetween();
        }

        return candyGO;
    }

#if DEBUG
    [ContextMenu("Stop All Coroutines")]
    private void DebugStopCoroutines()
    {
        StopAllCoroutines();
    }
#endif
}
