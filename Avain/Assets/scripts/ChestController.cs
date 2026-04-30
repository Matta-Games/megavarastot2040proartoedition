using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int requiredKeyID = 1;
    [SerializeField] private Animator chestAnimator;

    public void Open(PlayerInventory playerInv)
    {
        // fallback to singleton if null is passed
        if (playerInv == null)
        {
            playerInv = PlayerInventory.Instance;
        }

        if (playerInv == null)
            return;

        if (playerInv.HasKey(requiredKeyID))
        {
            chestAnimator.SetTrigger("Open");
            playerInv.RemoveKey();
        }
    }
}
