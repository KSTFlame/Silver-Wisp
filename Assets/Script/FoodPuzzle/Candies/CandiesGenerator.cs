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

    [SerializeField]
    private VectorRange _range;

    private CandiesBasket _basket;

    /// <summary>
    /// Initilizes CandiesGenerator.
    /// </summary>
    /// <param name="basket">Candies Basket</param>
    public void Init(CandiesBasket basket)
    {
        _basket = basket;
    }

    /// <summary>
    /// Spawns a candy.
    /// </summary>
    /// <returns>Spawned GameObject Candy.</returns>
    protected override GameObject SpawnObject()
    {
        GameObject candyGO = base.SpawnObject();

        if (candyGO.TryGetComponent(out Candy candy))
        {
            candy.Init(Pool, _basket);
            candy.transform.position = _range.RandomVectorBetween();
        }

        return candyGO;
    }

#if DEBUG
    [ContextMenu("Stop Spawn Routine")]
    private void DebugStopCoroutines()
    {
        StopAllCoroutines();
    }
#endif
}
