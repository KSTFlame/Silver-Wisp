using UnityEngine;

public class CandiesManager : MonoBehaviour
{
    [field: SerializeField, Header("Basket")]
    public CandiesBasket Basket { get; private set; }

    [field: SerializeField, Header("Generator")]
    public CandiesGenerator Generator { get; private set; }

    private void Start()
    {
        Generator.Init(Basket);
        Generator.StartSpawner();
    }

    private void OnEnable()
    {
        Basket.OnCandiesMissed += () => Debug.Log("Player Lose!");
        Basket.OnCandiesReached += () => Debug.Log("Player Won!");
    }
}
