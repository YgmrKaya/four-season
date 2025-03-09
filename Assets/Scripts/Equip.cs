using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equip : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EquipSO equipSO;
    public EquipSO EquipSO { get => equipSO; set => equipSO = value; }

    [SerializeField] private Image icon;
    private EquipType equipType;

    [SerializeField] InventoryManager inventoryManager;
    public void Initialized(EquipSO equipSO, InventoryManager manager)
    {
        this.equipSO = equipSO;
        icon.sprite = equipSO.equipSprite;
        equipType = equipSO.equipType;
        inventoryManager = manager;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryManager.SelectEquip(this);
    }
}
