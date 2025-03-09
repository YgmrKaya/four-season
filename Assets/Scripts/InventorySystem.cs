using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private Transform inventoryParent;
    [SerializeField] private GameObject item;
    public void AddItem(EquipSO equipSO)
    {
        GameObject obj = Instantiate(item, inventoryParent);
        obj.GetComponent<Equip>().Initialized(equipSO);
        //item.transform.SetParent(inventoryParent);
        //item.AddComponent<SpriteRenderer>().sprite = equipSO.equipSprite;
        //item.AddComponent<Equip>().equipType = equipSO.equipType;
    }

}
