using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private ChestController chest;

    private PlayerInventory playerInv;
    private bool playerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chest"))
        {
            playerNearby = true;
            playerInv = FindObjectOfType<PlayerInventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chest"))
        {
            playerNearby = false;
            playerInv = null;
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // fallback to singleton if FindObjectOfType failed
            if (playerInv == null)
            {
                playerInv = PlayerInventory.Instance;
            }

            chest.Open(playerInv);
        }
    }
}
