using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private int requiredKeyID = 1;
    [SerializeField] private Animator chestAnimator;

    public void Open()
    {
        var inv = PlayerInventory.Instance;

        if (inv == null)
            return;

        if (inv.HasKey(requiredKeyID))
        {
            chestAnimator.SetTrigger("Open");
            inv.RemoveKey();
        }
    }
}
