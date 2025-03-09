using UnityEngine;

public class CollectItem : MonoBehaviour, ICollectable
{
    [SerializeField] InventorySystem inventorySystem;
    [SerializeField] EquipSO equipSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect()
    {
        inventorySystem.AddItem(equipSO);
        Destroy(gameObject);
    }
}
