using UnityEngine;

[RequireComponent (typeof(BowlContainer))]
public class BowlController : MonoBehaviour
{
    public bool CanPullOver;

    private KeyCode _pullOverInput;
    private CandiesBasket _basket;
    
    public BowlContainer Container { get; private set; }

    private void Awake()
    {
        TryGetComponent(out BowlContainer container);
        Container = container;
    }

    /// <summary>
    /// Initializes the BowlController.
    /// </summary>
    /// <param name="keycodePulloverBowl">Keycode input needed for PullOver.</param>
    /// <param name="basket">Candies Basket.</param>
    public void Init(KeyCode keycodePulloverBowl, CandiesBasket basket)
    {
        Container.Init();
        _pullOverInput = keycodePulloverBowl;
        _basket = basket;
    }

    /// <summary>
    /// Adds N candies to the basket.
    /// </summary>
    public void PullOver()
    {
        _basket.CatchCandy(Container.Count);
        Container.Clear();
    }

    private void Update()
    {
        if (CanPullOver && Input.GetKeyDown(_pullOverInput))
        {
            Debug.Log("Input");
            PullOver();
        }
    }
}