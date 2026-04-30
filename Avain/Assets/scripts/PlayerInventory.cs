using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int currentKeyID = 0;

    public void AddKey(int keyID)
    {
        currentKeyID = keyID;
        Debug.Log("Player picked up key ID: " + keyID);
    }

    public bool HasKey(int keyID)
    {
        return currentKeyID == keyID;
    }

    public void RemoveKey()
    {
        currentKeyID = 0;
    }
}