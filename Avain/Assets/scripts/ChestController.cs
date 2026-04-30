using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int requiredKeyID = 1;
    [SerializeField] private Animator chestAnimator;

    public void Open(PlayerInventory playerInv)
    {
        if (playerInv == null)
        {
            return;
        }

        if (playerInv.HasKey(requiredKeyID))
        {
            chestAnimator.SetTrigger("Open");
            playerInv.RemoveKey();
        }
        else
        {
        }
    }
}
