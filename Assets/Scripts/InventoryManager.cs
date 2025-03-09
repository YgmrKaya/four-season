using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Transform inventoryParent;
    [SerializeField] private GameObject item;

    public static InventoryManager Instance; // Singleton olarak kullanacaðýz.

    private Equip selectedEquip; // Þu an seçili olan item

    private void Awake()
    {
        Instance = this; // Singleton olarak eriþimi saðlýyoruz.
    }
    public void AddItem(EquipSO equipSO)
    {
        GameObject obj = Instantiate(item, inventoryParent);
        obj.GetComponent<Equip>().Initialized(equipSO, this);
        //item.transform.SetParent(inventoryParent);
        //item.AddComponent<SpriteRenderer>().sprite = equipSO.equipSprite;
        //item.AddComponent<Equip>().equipType = equipSO.equipType;
    }


    public void SelectEquip(Equip equip)
    {
        selectedEquip = equip;
        Debug.Log("Seçili item: " + selectedEquip.EquipSO.equipType);
    }

    public Equip GetSelectedEquip()
    {
        return selectedEquip;
    }

    public void RemoveSelectedEquip()
    {
        selectedEquip = null;
    }

    public void DeleteEquip()
    {
        Destroy(selectedEquip.gameObject);
    }
}
