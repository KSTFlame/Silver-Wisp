public interface IPooledObject
{
    Pool RelatedPool { get; }

    /// <summary>
    /// Associates the pool.
    /// </summary>
    /// <param name="associatedPool">Pool to associate.</param>
    void AssociatePool(Pool associatedPool);

    /// <summary>
    /// Disposes the object and returns it to the pool.
    /// </summary>
    void Dispose();
}