using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private ChestController currentChest;
    private PlayerInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var chest = hit.collider.GetComponentInParent<ChestController>();
        if (chest != null)
        {
            currentChest = chest;
            Debug.Log("Near chest");
        }
    }

    private void Update()
    {
        if (currentChest == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentChest.Open(inventory);
            Debug.Log("Opened chest");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var chest = other.GetComponentInParent<ChestController>();
        if (chest != null && chest == currentChest)
        {
            currentChest = null;
            Debug.Log("Left chest");
        }
    }
}
