
using System;

public class BowlContainer : Containter<Candy>
{
    public event Action<int, int> OnBowlContainerInit;

    /// <summary>
    /// Initializes the BowlContainer.
    /// </summary>
    public void Init()
    {
        OnBowlContainerInit?.Invoke(Count, MaxSize);
    }
}