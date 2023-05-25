using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectItemsSpawner : MonoBehaviour
{
    [field: SerializeField, Header("Pooler")]
    public Pool Pool { get; private set; }

    [field: SerializeField, Min(0)]
    private float _spawnRate = 1f;

    /// <summary>
    /// Begins the spawn.
    /// </summary>
    public virtual void StartSpawner()
    {
        StartCoroutine(SpawObjectsRoutine());
    }

    /// <summary>
    /// Spawns the GameObject.
    /// </summary>
    /// <returns>Spawned GameObject.</returns>
    protected virtual GameObject SpawnObject()
    {
        return Pool.Get();
    }

    /// <summary>
    /// Starts the spawn routine.
    /// </summary>
    private IEnumerator SpawObjectsRoutine()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
