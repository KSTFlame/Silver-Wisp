
using System;

public class BowlContainer : Containter<Candy>
{
    public event Action<int, int> OnBowlContainerInit;

    public void Init()
    {
        OnBowlContainerInit?.Invoke(Count, MaxSize);
    }
}