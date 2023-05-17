using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectItemsSpawner : MonoBehaviour
{
    [field: SerializeField, Header("Pooler")]
    public Pool Pool { get; private set; }

    [field: SerializeField, Min(0)]
    private float _spawnRate = 1f;

    protected virtual void StartSpawnerRoutine()
    {
        StartCoroutine(SpawObjectsRoutine());
    }

    protected virtual GameObject SpawnObject()
    {
        return Pool.Get();
    }

    private IEnumerator SpawObjectsRoutine()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
