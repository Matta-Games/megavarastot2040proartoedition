using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private int keyID = 1; // 1 = kulta, 2 = hopea

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            inv.AddKey(keyID);

            Destroy(gameObject);
        }
    }
}