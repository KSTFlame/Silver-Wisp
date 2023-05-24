using UnityEngine;

public class CandyChest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBowlManager playerBowlManager))
        {
            playerBowlManager.BowlController.CanPullOver = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerBowlManager playerBowlManager))
        {
            playerBowlManager.BowlController.CanPullOver = false;
        }
    }
}
