using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Candy : ObjectItem, IPooledObject
{
    public Pool RelatedPool { get; private set; }
    public CandiesBasket Basket { get; private set; }

    private Rigidbody _rb;

    private void Awake()
    {
        TryGetComponent(out _rb);
    }

    /// <summary>
    /// Initilizes the candy.
    /// </summary>
    /// <param name="associatedPool">Candies Pool.</param>
    /// <param name="basket">Candies Basket.</param>
    public void Init(Pool associatedPool, CandiesBasket basket)
    {
        AssociatePool(associatedPool);
        Basket = basket;
    }

    /// <inheritdoc/>
    public void AssociatePool(Pool associatedPool)
    {
        RelatedPool = associatedPool;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _rb.velocity = Vector3.zero;
        RelatedPool.Dispose(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dispose();
        if (other.TryGetComponent(out PlayerBowlManager bowlmanager))
        {
            bowlmanager.BowlController.Container.Add(this);
            return;
        }

        Basket.MissCandy();
    }
}
