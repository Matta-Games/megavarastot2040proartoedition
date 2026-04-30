using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private int keyID = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inv = other.GetComponent<PlayerInventory>();

            if (inv == null)
                return;

            inv.AddKey(keyID);

            Destroy(gameObject);
        }
    }
}
