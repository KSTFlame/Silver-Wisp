using UnityEngine;

[RequireComponent(typeof(BowlController))]
public class PlayerBowlManager : MonoBehaviour, IPlayer
{
    [SerializeField, Header("Candies Basket")]
    private CandiesBasket _basket;

    [SerializeField, Header("Inputs")]
    private KeyCode _pullOverBowlInput = KeyCode.Space;

    public BowlController BowlController { get; private set; }

    private void Awake()
    {
        TryGetComponent(out BowlController bowl);
        BowlController = bowl;
    }

    private void Start()
    {
        BowlController.Init(_pullOverBowlInput, _basket);
    }
}