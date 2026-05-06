using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private ChestController chest;
    private bool chestNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chest"))
        {
            chestNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chest"))
        {
            chestNearby = false;
        }
    }

    void Update()
    {
        if (chestNearby && Input.GetKeyDown(KeyCode.E))
        {
            chest.Open();
        }
    }
}
