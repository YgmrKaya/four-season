using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Transform inventoryParent;
    [SerializeField] private GameObject item;

    public static InventoryManager Instance; // Singleton olarak kullanaca��z.

    private Equip selectedEquip; // �u an se�ili olan item

    private void Awake()
    {
        Instance = this; // Singleton olarak eri�imi sa�l�yoruz.
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
        Debug.Log("Se�ili item: " + selectedEquip.EquipSO.equipType);
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
