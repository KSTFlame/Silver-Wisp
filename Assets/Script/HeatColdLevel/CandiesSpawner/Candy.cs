using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Candy : ObjectItem, IPooledObject
{
    public Pool RelatedPool { get; private set; }
    public CandiesGenerator CandiesGenerator { get; private set; }

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Init(Pool associatedPool, CandiesGenerator candyGenerator)
    {
        AssociatePool(associatedPool);
        CandiesGenerator = candyGenerator;
    }

    public void AssociatePool(Pool associatedPool)
    {
        RelatedPool = associatedPool;
    }

    public void Dispose()
    {
        _rb.velocity = Vector3.zero;
        RelatedPool.Dispose(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dispose();

        if(other.TryGetComponent(out IPlayer player))
        {
            CandiesGenerator.CatchCandy();
            return;
        }

        CandiesGenerator.MissCandy();
    }
}
