using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public int currentKeyID = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

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
